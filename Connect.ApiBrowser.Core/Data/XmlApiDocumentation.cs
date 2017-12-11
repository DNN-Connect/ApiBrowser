using Connect.ApiBrowser.Core.Models.Members;
using Connect.ApiBrowser.Core.Common;
using System;
using System.Collections.Generic;
using System.Xml;
using DotNetNuke.Services.Exceptions;
using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Models.Components;
using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.Controllers;
using Connect.ApiBrowser.Core.Models;

namespace Connect.ApiBrowser.Core.Data
{
    public class XmlApiDocumentation : XmlDocument
    {
        public int ModuleId { get; set; } = -1;
        public string FilePath { get; set; } = "";
        public bool IsValid { get; set; } = false;
        public string File { get; set; } = "";
        public string Version { get; set; } = "";
        public DateTime Generated { get; set; } = DateTime.Now;
        private DateTime StartTime { get; set; } = DateTime.Now;

        public XmlApiDocumentation(string filePath, int moduleId) : base()
        {
            base.Load(filePath);
            ModuleId = moduleId;
            FilePath = filePath;
            try
            {
                File = this.DocumentElement.Attributes["file"].InnerText;
                Version = this.DocumentElement.Attributes["version"].InnerText;
                Generated = DateTime.Parse(this.DocumentElement.Attributes["generated"].InnerText);
                IsValid = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void AddToModule()
        {
            StartTime = DateTime.Now;
            string logFile = System.IO.Path.GetDirectoryName(FilePath) + "\\" + System.IO.Path.GetFileNameWithoutExtension(FilePath) + ".log";
            var log = new System.IO.StreamWriter(logFile, false);

            log.Log(StartTime, "Beginning import of {0}", FilePath);
            Component component = Sprocs.GetOrCreateComponent(ModuleId, File, Version);
            log.Log(StartTime, "Component is {0}, ID={1}, version={2}", component.ComponentName, component.ComponentId, Version);
            List<int> handledClassIds = new List<int>();
            foreach (XmlNode namespaceNode in DocumentElement.SelectNodes("namespace"))
            {
                ApiNamespace ns = ApiNamespaceRepository.Instance.GetOrCreateNamespace(ModuleId, namespaceNode.Attributes["name"].InnerText);
                log.Log(StartTime, "Namespace {0}", ns.NamespaceName);
                foreach (XmlNode classNode in namespaceNode.SelectNodes("class"))
                {
                    List<int> handledMemberIds = new List<int>();
                    bool isDeprecated = false;
                    string deprecationMessage = "";
                    if (classNode.SelectSingleNode("deprecation") != null)
                    {
                        isDeprecated = true;
                        deprecationMessage = classNode.SelectSingleNode("deprecation").InnerText;
                    }
                    try
                    {
                        ApiClass cl = Sprocs.GetOrCreateClass(ns.NamespaceId, component.ComponentId, classNode.Attributes["name"].InnerText, classNode.SelectSingleNode("declaration").InnerText, classNode.SelectSingleNode("documentation").InnerXml.Trim(), Version, isDeprecated, deprecationMessage);
                        log.Log(StartTime, "Class {0} (ID={1})", cl.ClassName, cl.ClassId);
                        foreach (XmlNode memberNode in classNode.SelectNodes("constructors/constructor"))
                        {
                            handledMemberIds.Add(AddMemberToClass(ModuleId, cl.ClassId, memberNode, MemberType.Constructor, ref log));
                        }
                        foreach (XmlNode memberNode in classNode.SelectNodes("methods/method"))
                        {
                            handledMemberIds.Add(AddMemberToClass(ModuleId, cl.ClassId, memberNode, MemberType.Method, ref log));
                        }
                        foreach (XmlNode memberNode in classNode.SelectNodes("fields/field"))
                        {
                            handledMemberIds.Add(AddMemberToClass(ModuleId, cl.ClassId, memberNode, MemberType.Field, ref log));
                        }
                        foreach (XmlNode memberNode in classNode.SelectNodes("properties/property"))
                        {
                            handledMemberIds.Add(AddMemberToClass(ModuleId, cl.ClassId, memberNode, MemberType.Property, ref log));
                        }
                        foreach (XmlNode memberNode in classNode.SelectNodes("events/event"))
                        {
                            handledMemberIds.Add(AddMemberToClass(ModuleId, cl.ClassId, memberNode, MemberType.Event, ref log));
                        }
                        foreach (var m in MemberRepository.Instance.GetMembersByApiClass(cl.ClassId))
                        {
                            if (!handledMemberIds.Contains(m.MemberId))
                            {
                                Sprocs.MemberDisappeared(m.MemberId, Version);
                            }
                        }
                        handledClassIds.Add(cl.ClassId);
                        log.Log(StartTime, "Finished class {0}", cl.ClassName);
                    }
                    catch (Exception ex)
                    {
                        Exceptions.LogException(ex);
                    }
                }
            }

            foreach (ApiClass c in ApiClassRepository.Instance.GetApiClassesByComponent(component.ComponentId))
            {
                if (!handledClassIds.Contains(c.ClassId))
                {
                    Sprocs.ClassDisappeared(c.ClassId, Version);
                }
            }

            try
            {
                System.IO.File.Delete(this.FilePath);
                log.Log(StartTime, "Deleted {0}", FilePath);
            }
            catch (Exception ex)
            {
                log.Log(StartTime, "Could not delete {0}", FilePath);
            }

            log.Log(StartTime, "Finished component {0}", component.ComponentName);
            log.Flush();
            log.Close();

        }

        private int AddMemberToClass(int moduleId, int classId, XmlNode memberNode, MemberType memberType, ref System.IO.StreamWriter log)
        {

            int res = -1;
            bool isDeprecated = false;
            string deprecationMessage = "";
            if (memberNode.SelectSingleNode("deprecation") != null)
            {
                isDeprecated = true;
                deprecationMessage = memberNode.SelectSingleNode("deprecation").InnerText;
            }


            try
            {
                Member m = Sprocs.GetOrCreateMember(classId, (int)memberType, memberNode.Attributes["name"].InnerText, memberNode.SelectSingleNode("declaration").InnerText, memberNode.SelectSingleNode("documentation").InnerXml.Trim(), Version, isDeprecated, deprecationMessage);
                log.Log(StartTime, "Member {0} (ID={1})", m.MemberName, m.MemberId);
                foreach (XmlNode codeNode in memberNode.SelectNodes("codeblock"))
                {
                    CodeBlock cb = new CodeBlock
                    {
                        ModuleId = moduleId,
                        Body = codeNode.SelectSingleNode("body").InnerText,
                        Hash = codeNode.SelectSingleNode("body").Attributes["hash"].InnerText
                    };
                    CodeBlocksController.SaveCodeBlock(cb);
                    log.Log(StartTime, "Codeblock {0}", cb.Hash);
                    MemberCodeBlock mcb = new MemberCodeBlock
                    {
                        EndColumn = int.Parse(codeNode.SelectSingleNode("location").Attributes["ec"].InnerText),
                        EndLine = int.Parse(codeNode.SelectSingleNode("location").Attributes["el"].InnerText),
                        StartColumn = int.Parse(codeNode.SelectSingleNode("location").Attributes["sc"].InnerText),
                        StartLine = int.Parse(codeNode.SelectSingleNode("location").Attributes["sl"].InnerText),
                        FileName = codeNode.SelectSingleNode("location").InnerText,
                        MemberId = m.MemberId,
                        CodeHash = codeNode.SelectSingleNode("body").Attributes["hash"].InnerText,
                        Version = Version
                    };
                    if (mcb.EndLine != 0 && mcb.EndLine > mcb.StartLine)
                    {
                        Sprocs.RegisterCodeBlock(mcb.MemberId, mcb.CodeHash, mcb.Version, mcb.FileName, (int)mcb.StartLine, (int)mcb.StartColumn, (int)mcb.EndLine, (int)mcb.EndColumn);
                    }
                }

                res = m.MemberId;

            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
            }

            return res;

        }
    }
}
