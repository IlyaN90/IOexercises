using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace IOhomework
{
    class Program
    {
        static void WriteToFile(string fileOne, string fileTwo, List<string> list)
        {
            List<string> list2 = new List<string>(ConcatFile(fileTwo));
            int listSize = list.Count;
            int list2Size = list2.Count;
            StreamWriter sw = File.AppendText(fileTwo);
            using (sw)
            {
                for (int i = 0; i < listSize; i++)
                {
                   // sw.WriteLine(list[i]);
                }
            }
        }

        static List<string> ConcatFile(string fileOne)
        {
            List<string> list = new List<string>();
            StreamReader reader = new StreamReader(fileOne);
            using (reader)
            {
                string line = reader.ReadLine();
                Console.WriteLine(fileOne);
                list.Add(line);
                while (line != null)
                {
                    line = reader.ReadLine();
                    list.Add(line);
                }
            }
            return list;
        }

        static void ReadFile(string fileOne)
        {
            StreamReader reader = new StreamReader(fileOne);
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if(lineNumber%2>0)
                   // Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }
            }       
        }

        static void XMLExtractor(string fileThree)
        {
            List<string> list = new List<string>(ConcatFile(fileThree));
            Console.WriteLine("Size of list = " + list.Count);
            string everything = "";
            foreach(string line in list)
            {
                if (line != null) 
                { 
                    everything += line;
                }
            }
            Console.WriteLine(everything);
            string pattern = ">(.*?)<";
            Regex rgx = new Regex(pattern);
           // MatchCollection matches = Regex.Matches(everything, pattern);
            foreach(Match match in rgx.Matches(everything))
            {
                if (match != null) 
                { 
                Console.WriteLine(match);
                }
            }

        }

        static void Main(string[] args)
        {
            string fileOne = @"C:\Users\nagib\source\repos\IOhomework\IOhomework\TextFile1.txt";
            string fileTwo = @"C:\Users\nagib\source\repos\IOhomework\IOhomework\TextFile2.txt";
            string fileThree = @"C:\Users\nagib\source\repos\IOhomework\IOhomework\TextFile3.txt";
            ReadFile(fileOne);
            List<string> list = new List<string>(ConcatFile(fileOne));
            WriteToFile(fileOne,fileTwo, list);
            XMLExtractor(fileThree);
        }
    }
}
