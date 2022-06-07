using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpecFlowProject2.Hooks
{
    public class ConsoleOutput 
    {
        public static void console(String fileName)
        {
            string UserName = System.Environment.UserName;
            //string fileName = @"D:\nm.txt";
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine("This is a line of text");
            Console.WriteLine("Everything written to Console.Write() or");
            Console.WriteLine("Console.WriteLine() will be written to a file");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            var files = File.ReadAllLines(fileName);
            files.ToList().ForEach(s => Console.WriteLine(s));
            Console.WriteLine("Done");
        }
    }
}
