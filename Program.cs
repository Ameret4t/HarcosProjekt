using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Program
    {

        static List<Harcos> harcosok;

        static void Main(string[] args)
        {
            harcosok = new List<Harcos>();
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

            Jatek();

        }



        public static void Jatek()
        {
            Console.WriteLine("Adja meg a harcosa nevét!");
            string nev = Console.ReadLine();
            Console.WriteLine("Adja meg a státuszsablont (1, 2 vagy 3)!");
            int statusz = int.Parse(Console.ReadLine());

            Harcos User = new Harcos(nev, statusz);

            Console.WriteLine("\nAz ön harcosának adatai: \n" + User);
            Console.WriteLine("\nAz ellenfelek adatai: ");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]) ;
            }

            Console.WriteLine("\nMit szeretne tenni?\na) Megküzdeni egy harcossal\nb) Gyógyulni\nc) Kilépni");

            string dontes = "";
            while (!dontes.Equals("c"))
            {
                dontes = Console.ReadLine();
                if (dontes.Equals("a"))
                {
                    Console.WriteLine("Adja meg a választott ellenfél sorszámát!");
                    User.megKuzd(harcosok[int.Parse(Console.ReadLine()) - 1]);
                    if (User.Eletero <= 0)
                    {
                        Console.WriteLine("Vesztettél");
                        Console.WriteLine("A játék véget ért és 5 másodpercen belül ki fog lépni.");
                        for (int i = 5; i > 0; i--)
                        {
                            Console.WriteLine(i + "..");
                            Thread.Sleep(1000);
                        }
                        
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Nyertél");
                    }
                }
                else if (dontes.Equals("b"))
                {
                    User.Gyogyul();
                }
                else if (dontes.Equals("c"))
                {
                    Console.WriteLine("A játék véget ért és 5 másodpercen belül ki fog lépni.");
                    for (int i = 5; i > 0; i--)
                    {
                        Console.WriteLine(i + "..");
                        Thread.Sleep(1000);
                    }

                    Environment.Exit(0);

                }
                Console.WriteLine("\nAz ön harcosának adatai: \n" + User);
                Console.WriteLine("\nMit szeretne tenni?\na) Megküzdeni egy harcossal\nb) Gyógyulni\nc) Kilépni");
                
            }
            

           
                    
               
            
            
        }


    }
}
