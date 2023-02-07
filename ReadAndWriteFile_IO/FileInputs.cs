using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;

namespace ReadAndWriteFile_IO
{
    //UC_13 Read Write with FileIo
    public class FileInputs
    {
        public string path = @"D:\Batch 244\FileIO_New\ReadAndWriteFile_IO\PersonDetails.txt";

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


        //UC_14 Read&Write with CSV File
        public void ReadFromCSVToJson()
        {
            string csvpath = @"D:\Batch 244\FileIO_New\ReadAndWriteFile_IO\DataFiles\Addresses.csv";
            string CsvWritePath = @"D:\Batch 244\FileIO_New\ReadAndWriteFile_IO\DataFiles\writeData.csv";
            string Jsonpath = @"D:\Batch 244\FileIO_New\ReadAndWriteFile_IO\DataFiles\person.json";

            using (StreamReader sr = new StreamReader(csvpath))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();

                //    Console.WriteLine("Reading records from address book csv file");
                //    foreach (Contact item in records)
                //    {
                //        Console.Write(item.FirstName);
                //        Console.Write("\t" + item.LastName);
                //        Console.Write("\t" + item.MobNumber);
                //        Console.Write("\t" + item.Email);
                //        Console.Write("\t" + item.Address);
                //        Console.Write("\t" + item.City);
                //        Console.Write("\t" + item.State);
                //        Console.Write("\t" + item.Zip);
                //    }
                //    Console.ReadLine();

                //}

                //UC14_WriteOperation

                using (StreamWriter sw = new StreamWriter(CsvWritePath))
                using (var csvwriter = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    csvwriter.WriteRecords(records);
                    Console.WriteLine("\n Data SucessFully Written Into CSV File !");
                }

                //UC15_CSVToJSON File

                JsonSerializer serializer = new JsonSerializer();
                using (var writer = new StreamWriter(Jsonpath))
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonWriter, records);
                }
                Console.ReadKey();

            }
        }
    }
}
        
                        
        
    
   



       
        
    

