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
using System.Text.RegularExpressions;
using Connect.ApiBrowser.Core.Models.ComponentHistories;

namespace Connect.ApiBrowser.Core.Data
{
    public class XmlApiDocumentation : XmlDocument
    {
        public int ModuleId { get; set; } = -1;
        public ComponentHistory HistoryItem { get; set; } = null;
        public string FilePath { get; set; } = "";
        public bool IsValid { get; set; } = false;
        public string File { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Version { get; set; } = "";
        public string VersionNormalized { get; set; } = "";
        public int CodeLines { get; set; } = 0;
        public int CommentLines { get; set; } = 0;
        public int EmptyLines { get; set; } = 0;
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
                var assemblyNode = this.DocumentElement.SelectSingleNode("assembly");
                FullName = assemblyNode.SelectSingleNode("fullName").InnerText;
                Version = assemblyNode.SelectSingleNode("version").InnerText;
                VersionNormalized = assemblyNode.SelectSingleNode("version").Attributes["normalized"].InnerText;
                Generated = DateTime.Parse(this.DocumentElement.Attributes["generated"].InnerText);
                CodeLines = int.Parse(assemblyNode.SelectSingleNode("codeLines").InnerText);
                CommentLines = int.Parse(assemblyNode.SelectSingleNode("commentLines").InnerText);
                EmptyLines = int.Parse(assemblyNode.SelectSingleNode("emptyLines").InnerText);
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
            ComponentHistory historyItem = Sprocs.GetOrCreateComponentHistory(component.ComponentId, FullName, Version, VersionNormalized, CodeLines, CommentLines, EmptyLines);
            log.Log(StartTime, "Component is {0}, ID={1}, version={2}", component.ComponentName, component.ComponentId, Version);
            foreach (XmlNode depNode in DocumentElement.SelectSingleNode("dependencies").SelectNodes("dependency"))
            {
                var dep = Sprocs.GetOrCreateDependency(historyItem.ComponentHistoryId, depNode.InnerText, depNode.Attributes["version"].InnerText, depNode.Attributes["versionnorm"].InnerText, depNode.Attributes["name"].InnerText);
            }
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
                        var documentation = classNode.SelectSingleNode("documentation").InnerXml.Trim();
                        var description = tryGetDescription(documentation);
                        ApiClass cl = Sprocs.GetOrCreateClass(ns.NamespaceId, component.ComponentId, classNode.Attributes["name"].InnerText.Trim(), classNode.SelectSingleNode("fullName").InnerText.Trim(), classNode.SelectSingleNode("declaration").InnerText.Trim(), documentation, description, Version, isDeprecated, deprecationMessage.Trim(),
                            bool.Parse(classNode.Attributes["IsAbstract"].InnerText),
                            bool.Parse(classNode.Attributes["IsAnsiClass"].InnerText),
                            bool.Parse(classNode.Attributes["IsArray"].InnerText),
                            bool.Parse(classNode.Attributes["IsAutoClass"].InnerText),
                            bool.Parse(classNode.Attributes["IsAutoLayout"].InnerText),
                            bool.Parse(classNode.Attributes["IsBeforeFieldInit"].InnerText),
                            bool.Parse(classNode.Attributes["IsByReference"].InnerText),
                            bool.Parse(classNode.Attributes["IsClass"].InnerText),
                            bool.Parse(classNode.Attributes["IsDefinition"].InnerText),
                            bool.Parse(classNode.Attributes["IsEnum"].InnerText),
                            bool.Parse(classNode.Attributes["IsExplicitLayout"].InnerText),
                            bool.Parse(classNode.Attributes["IsFunctionPointer"].InnerText),
                            bool.Parse(classNode.Attributes["IsGenericInstance"].InnerText),
                            bool.Parse(classNode.Attributes["IsGenericParameter"].InnerText),
                            bool.Parse(classNode.Attributes["IsImport"].InnerText),
                            bool.Parse(classNode.Attributes["IsInterface"].InnerText),
                            bool.Parse(classNode.Attributes["IsNested"].InnerText),
                            bool.Parse(classNode.Attributes["IsNestedAssembly"].InnerText),
                            bool.Parse(classNode.Attributes["IsNestedPrivate"].InnerText),
                            bool.Parse(classNode.Attributes["IsNestedPublic"].InnerText),
                            bool.Parse(classNode.Attributes["IsNotPublic"].InnerText));
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
                        log.Log(StartTime, "Exception {0}. Stacktrace: {1}.", ex.Message, ex.StackTrace);
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
                var documentation = memberNode.SelectSingleNode("documentation").InnerXml.Trim();
                var description = tryGetDescription(documentation);
                var fullName = memberNode.SelectSingleNode("fullName").InnerText.Trim();
                var m = Sprocs.GetOrCreateMember(classId, (int)memberType, memberNode.Attributes["name"].InnerText.Trim(), fullName, memberNode.SelectSingleNode("declaration").InnerText, documentation, description, Version, isDeprecated, deprecationMessage.Trim());
                var existingCodeblocks = MemberCodeBlockRepository.Instance.GetMemberCodeBlocksByMember(m.MemberId);
                log.Log(StartTime, "Member {0} (ID={1})", m.MemberName, m.MemberId);
                res = m.MemberId;
                MemberCodeBlock block = null;
                foreach (XmlNode codeNode in memberNode.SelectNodes("codeblock"))
                {
                    var cb = CodeBlock.FromXmlBlock(moduleId, codeNode);

                    if (!cb.IsPresentIn(existingCodeblocks))
                    {
                        CodeBlocksController.SaveCodeBlock(cb, System.IO.Path.GetDirectoryName(FilePath));
                        log.Log(StartTime, "New Codeblock {0}", cb.Hash);
                        MemberCodeBlock mcb = new MemberCodeBlock
                        {
                            EndColumn = cb.EndColumn,
                            EndLine = cb.EndLine,
                            StartColumn = cb.StartColumn,
                            StartLine = cb.StartLine,
                            FileName = cb.FileName,
                            MemberId = m.MemberId,
                            CodeHash = cb.Hash,
                            Version = Version
                        };
                        if (mcb.EndLine != 0 && mcb.EndLine > mcb.StartLine)
                        {
                            block=Sprocs.GetOrCreateMemberCodeBlock(mcb.MemberId, mcb.CodeHash, mcb.Version, mcb.FileName, (int)mcb.StartLine, (int)mcb.StartColumn, (int)mcb.EndLine, (int)mcb.EndColumn);
                        }
                    }
                    if (block == null)
                    {
                        block = MemberCodeBlockRepository.Instance.GetMemberCodeBlock(m.MemberId, Version);
                    }
                    foreach (XmlNode refNode in codeNode.SelectNodes("refs/ref"))
                    {
                        var refName = refNode.InnerText;
                        if (refName != fullName)
                        {
                            Sprocs.GetOrCreateReference(block.CodeBlockId, refName, int.Parse(refNode.Attributes["os"].InnerText));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                log.Log(StartTime, "Exception {0}. Stacktrace: {1}.", ex.Message, ex.StackTrace);
            }
            return res;
        }

        private string tryGetDescription(string documentation)
        {
            var m = Regex.Match(documentation, "(?si)<summary>(.*)</summary>(?-si)");
            if (m.Success)
            {
                return m.Groups[1].Value.Trim();
            }
            else
            {
                return "";
            }
        }
    }
}
