using System;
using System.IO;


namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            bool isHotKey;

            Console.WriteLine("Ctrl + S to save");
            Console.WriteLine("Enter to create a new line");

            var output = "";

            while (true)
            {
                input = Console.ReadKey(true);
                isHotKey = false;

                if ((input.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control
                    && input.Key == ConsoleKey.S)
                {
                    var fileName = DateTime.Now.Day.ToString() + "-" +
                                   DateTime.Now.Month.ToString() + "-" +
                                   DateTime.Now.Year.ToString() + "-" +
                                   DateTime.Now.Hour.ToString() + "-" +
                                   DateTime.Now.Minute.ToString() + "-" +
                                   DateTime.Now.Second.ToString() + ".txt";

                    var path = Directory.GetCurrentDirectory() + "\\" + fileName;

                    using (var sw = File.CreateText(path))
                    {
                        sw.WriteLine(output);
                    }

                    var dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                    var filesInfo = dirInfo.GetFiles();

                    foreach (var file in filesInfo)
                    {
                        if (file.Name != fileName) continue;
                        var size = file.Length;
                        Console.WriteLine("File successfully saved. " + size + " bytes");
                    }

                    output = "";
                    isHotKey = true;
                }


                if (!isHotKey)
                {
                    output += Console.ReadLine() + "\n";
                }
            } 
        }
    }
}