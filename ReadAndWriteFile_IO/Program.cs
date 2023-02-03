using System.IO;
using System.Runtime.CompilerServices;

namespace ReadAndWriteFile_IO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome File IO Operations");
            FileInputs fileInputs = new FileInputs();
            fileInputs.ReadFile();
            fileInputs.WriteFile();
        }
    }
}