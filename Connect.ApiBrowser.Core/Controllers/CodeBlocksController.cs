using Connect.ApiBrowser.Core.Models;
using DotNetNuke.Entities.Portals;
using System;
using System.IO.Compression;
using System.Text;

namespace Connect.ApiBrowser.Core.Controllers
{
    public class CodeBlocksController
    {
        public static void SaveCodeBlock(CodeBlock block)
        {
            string savePath = string.Format("{0}\\Api\\{1}\\CodeBlocks\\{2}\\{3}.resources", PortalSettings.Current.HomeDirectoryMapPath, block.ModuleId, block.Hash.Substring(0, 2), block.Hash.Substring(2));
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(savePath)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(savePath));
            if (!System.IO.File.Exists(savePath))
            {
                using (var fileOut = new System.IO.FileStream(savePath, System.IO.FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(fileOut, ZipArchiveMode.Create))
                    {
                        ZipArchiveEntry readmeEntry = archive.CreateEntry("body.txt");
                        readmeEntry.LastWriteTime = DateTime.Now;
                        using (var writer = new System.IO.StreamWriter(readmeEntry.Open()))
                        {
                            writer.Write(block.Body);
                        }
                    }
                }
            }
        }

        public static CodeBlock GetCodeBlock(int moduleId, string hash)
        {
            string retrievePath = string.Format("{0}\\Api\\{1}\\CodeBlocks\\{2}\\{3}.resources", PortalSettings.Current.HomeDirectoryMapPath, moduleId, hash.Substring(0, 2), hash.Substring(2));
            var res = new CodeBlock
            {
                Hash = hash,
                ModuleId = moduleId
            };
            if (System.IO.File.Exists(retrievePath))
            {
                using (ZipArchive archive = ZipFile.OpenRead(retrievePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name == "body.txt")
                        {
                            using (var stream = entry.Open())
                            {
                                using (var memIn = new System.IO.MemoryStream())
                                {
                                    int intSize = 2048;
                                    byte[] arrData = new byte[2048];
                                    intSize = stream.Read(arrData, 0, arrData.Length);
                                    while (intSize > 0)
                                    {
                                        memIn.Write(arrData, 0, intSize);
                                        intSize = stream.Read(arrData, 0, arrData.Length);
                                    }
                                    res.Body = Encoding.UTF8.GetString(memIn.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }
    }
}
