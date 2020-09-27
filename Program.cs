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

            Console.WriteLine("Harcosok a játékban: ");
            Console.WriteLine();
            
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]);
            }

            Jatek();

        }



        public static void Jatek()
        {
            Console.WriteLine();
            Console.WriteLine("Adja meg a harcosa nevét!");
            string nev = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Adja meg a státuszsablont (1, 2 vagy 3)!");
            Console.WriteLine("A státuszsablon értékei:\n1 -> HP: 15, DMG: 3\n2 -> HP:12, DMG: 4\n3 -> HP:8, DMG: 5");
            int statusz = int.Parse(Console.ReadLine());

            Harcos User = new Harcos(nev, statusz);

            Console.WriteLine();
            Console.WriteLine("\nAz ön harcosának adatai: \n" + User);
            Console.WriteLine();
            Console.WriteLine("\nAz ellenfelek adatai: ");
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine(harcosok[i]) ;
            }

            Console.WriteLine("Nyomjon egy gombot a játék megkezdéséhez!");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Mit szeretne tenni?\na) Megküzdeni egy harcossal\nb) Gyógyulni\nc) Kilépni");

            int korSzamlalo = 1;

            string dontes = "";
            while (!dontes.Equals("c"))
            {
                dontes = Console.ReadLine();
                if (dontes.Equals("a") && korSzamlalo % 3!=0 )
                {
                    korSzamlalo++;
                    Console.WriteLine("Adja meg a választott ellenfél sorszámát!");
                    User.megKuzd(harcosok[int.Parse(Console.ReadLine()) - 1]);

                    Console.WriteLine("A Harcosok éppen küzdenek...");
                    Thread.Sleep(3000);
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
                    else if (korSzamlalo % 3 == 0) {
                        korSzamlalo++;
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

                        Console.WriteLine("3. kör: Egy véletlenül választott ellenfél ellen is meg kell küzdenie!");
                        Random rnd = new Random();
                        int random = rnd.Next(1,4);
                        Console.WriteLine("Ön a {0}. sorszámú harcos ellen fog megküzdeni!", random);
                        Console.WriteLine("A Harcosok éppen küzdenek...");
                        Thread.Sleep(3000);
                        User.megKuzd(harcosok[random-1]);
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

                        Console.WriteLine("Gyógyítás folyamatban...");
                        Thread.Sleep(3000);

                        User.Gyogyul();
                        for (int i = 0; i < harcosok.Count; i++)
                        {
                            harcosok[i].Gyogyul();
                        }
                    }
                    
                    

                    Console.WriteLine("5 másodperc múlva visszakerül a választóképernyőhöz!");
                    Thread.Sleep(5000);
                    Console.Clear();
                }
                else if (dontes.Equals("b"))
                {
                    if (korSzamlalo%3!=0)
                    {
                        korSzamlalo++;
                        Console.WriteLine("Gyógyítás folyamatban...");
                        Thread.Sleep(3000);
                        User.Gyogyul();
                    }
                    else{
                        korSzamlalo++;

                        User.Gyogyul();

                        Console.WriteLine("3. kör: Egy véletlenül választott ellenfél ellen kell megküzdenie!");
                        Random rnd = new Random();
                        int random = rnd.Next(1, 4);
                        Console.WriteLine("Ön a {0}. sorszámú harcos ellen fog megküzdeni!", random);
                        User.megKuzd(harcosok[random - 1]);
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
                        Console.WriteLine("Gyógyítás folyamatban...");
                        Thread.Sleep(3000);
                        User.Gyogyul();
                        for (int i = 0; i < harcosok.Count; i++)
                        {
                            harcosok[i].Gyogyul();
                        }

                        
                    }
                    Console.WriteLine("5 másodperc múlva visszakerül a választóképernyőhöz!");
                    Thread.Sleep(5000);
                    Console.Clear();
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
