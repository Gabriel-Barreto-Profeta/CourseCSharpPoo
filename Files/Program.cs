using Files.Entities;
using System;
using System.Globalization;
using System.IO;


namespace Files
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();
            
            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);
                CheckFile checkFile = new CheckFile(Path.GetDirectoryName(sourceFilePath));
                var validaDirectory = Directory.Exists(checkFile.TargetFolderPath);

                if (validaDirectory)
                    checkFile.CheckExistingFile();
                else
                    Directory.CreateDirectory(checkFile.TargetFilePath);
                
                using (StreamWriter sw = File.AppendText(checkFile.TargetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);
                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
