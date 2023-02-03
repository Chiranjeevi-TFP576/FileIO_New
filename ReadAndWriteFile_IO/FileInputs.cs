using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadAndWriteFile_IO
{
    public class FileInputs
    {
        public string path = @"D:\Batch 244\ReadAndWriteFile_IO\PersonDetails.txt";
        public void ReadFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string data = String.Empty;
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("\nFile Not Found !");
            }
        }
        public void WriteFile()
        {
            string path = @"D:\Batch 244\ReadAndWriteFile_IO\PersonDetails.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                string data = "\nAddressBook";
                sw.WriteLine(data);
                sw.Close();
                Console.WriteLine(File.ReadAllText(path));
                Console.ReadLine();
            }
            
        }
    }



}       
        
    

