using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        private string[] syllables;

        void readFromFile(string fileName)
        {
            try
            {   
                using (StreamReader sr = new StreamReader(fileName))
                {
                    syllables = sr.ReadToEnd().Split(' ', '\n');
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        string createName(int syllablesRangeFrom, int syllablesRangeTo)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            int amountOfSyllables = random.Next(syllablesRangeFrom, syllablesRangeTo+1);
            Console.WriteLine(amountOfSyllables);
            for(int i = 0; i < amountOfSyllables; i++)
            {
                try
                {
                    stringBuilder.Append(syllables[random.Next(0, syllables.Length)]);
                }
                catch(System.NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }             
            }
            return stringBuilder.ToString();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.readFromFile("syllables.txt");
            int i = 1;
            while(i>0)
            {
                Console.WriteLine(program.createName(2, 4));
                i--;
            }
        }
    }
}
