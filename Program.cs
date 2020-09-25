using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Harcos> harcosok = new List<Harcos>();
            StreamReader sr = new StreamReader("harcosok.csv");
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] splitSor = sor.Split(';') ;
                Harcos harcos = new Harcos(splitSor[0], int.Parse(splitSor[1]));
                harcosok.Add(harcos);
            }
            sr.Close();

            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }

        }
    }
}
