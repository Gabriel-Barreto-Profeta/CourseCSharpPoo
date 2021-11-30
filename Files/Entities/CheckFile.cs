using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Entities
{
    class CheckFile
    {
        public string SourceFolderPath { get; set; }
        public string TargetFolderPath { get; set; }
        public string TargetFilePath { get; set; }
        public bool ExistingFile { get; set; }


        public CheckFile(string sourceFolderPath)
        {
            SourceFolderPath = sourceFolderPath;
            TargetFolderPath = SourceFolderPath + @"\out";
            TargetFilePath = TargetFolderPath + @"\summary.csv";
        }

        public void CheckExistingFile()
        {
            try
            {
                foreach (var file in Directory.EnumerateFiles(TargetFolderPath, "*.csv", SearchOption.AllDirectories)?.Where(x => x.Contains("summary")))
                {
                    File.Delete(file);
                    File.Create(TargetFilePath)?.Close();
                }

                if (!File.Exists(TargetFilePath))
                    File.Create(TargetFilePath)?.Close();
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
    }
}
