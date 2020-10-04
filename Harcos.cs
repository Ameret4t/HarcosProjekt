using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HarcosProjekt
{
    class Harcos
    {
        private string nev;
        private int szint;
        private int tapasztalat;
        private int eletero;
        private int alapEletero;
        private int alapSebzes;

        


        public Harcos(string nev, int statuszSablon)
        {
            this.nev = nev;
            this.szint = 1;
            this.tapasztalat = 0;
            if (statuszSablon == 1)
            {
                this.alapEletero = 15;
                this.alapSebzes = 3;
            }
            else if (statuszSablon == 2)
            {
                this.alapEletero = 12;
                this.alapSebzes = 4;
            }
            else
            {
                this.alapEletero = 8;
                this.alapSebzes = 5;
            }
            this.eletero = maxEletero;

        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set{
                if (this.eletero <= 0)
                {
                    this.tapasztalat = 0;
                }
                else{
                    this.tapasztalat = value;
                }

                if (this.tapasztalat >= this.szintLepeshez)
                {
                    this.tapasztalat = this.tapasztalat - this.szintLepeshez;
                    this.szint = this.szint++;
                    this.eletero = this.maxEletero;
                }
            }
        }
        public int Eletero { get => eletero; set {
                this.eletero = value;
                if (this.eletero>this.maxEletero)
                {
                    this.eletero = this.maxEletero;
                }
                if (this.eletero<=0)
                {
                    this.tapasztalat = 0;
                }
            }
        }
        public int AlapEletero { get => alapEletero; }
        public int Sebzes { get => alapSebzes + szint; }
        public int AlapSebzes { get => alapSebzes; }

        public int maxEletero { get => alapEletero + (szint * 3); }

        public int szintLepeshez { get =>  10 + szint * 5; }

        

        public override string ToString()
        {
            return String.Format("{0} - LVL: {1} - EXP: {2} - HP: {3}/{5} - DMG: {4}",nev, szint, tapasztalat, eletero, Sebzes, maxEletero);
        }

        /*public void megKuzd(Harcos Kihivott) {
            if (this.nev == Kihivott.nev )
            {
                Console.WriteLine("A két harcos neve megyezik!");
            }
            if (this.eletero == 0)
            {
                Console.WriteLine("A harcosa életereje 0!");
            }
            if (Kihivott.eletero==0)
            {
                Console.WriteLine("A kihívott harcos életereje 0!");
            }
            bool kihivoTamad = true;

            
            
                if (kihivoTamad)
                {
                    Kihivott.eletero = Kihivott.eletero - this.Sebzes;
                }
                else { 
                    this.eletero = this.eletero - Kihivott.Sebzes; 
                }

                kihivoTamad = !kihivoTamad;

                if (this.eletero != 0)
                {
                    this.tapasztalat = this.Tapasztalat + 5;
                }

                if (Kihivott.eletero != 0)
                {
                    Kihivott.tapasztalat = Kihivott.Tapasztalat + 5;
                }

                if (this.eletero == 0)
                {
                    Kihivott.tapasztalat = Kihivott.Tapasztalat + 10;
                }

                if (Kihivott.eletero != 0)
                {
                    this.tapasztalat = this.Tapasztalat + 10;
                }

                if (this.szintLepeshez >= this.tapasztalat)
                {
                    this.tapasztalat = this.tapasztalat - this.szintLepeshez;
                    this.szint = this.szint++;
                    this.eletero = this.maxEletero;
                }

                if (Kihivott.szintLepeshez >= Kihivott.tapasztalat)
                {
                    Kihivott.tapasztalat = Kihivott.tapasztalat - Kihivott.szintLepeshez;
                    Kihivott.szint = Kihivott.szint++;
                }
            

           
        }*/

        public void megKuzd(Harcos kihivott) {
            if (kihivott.nev == this.nev)
            {
                Console.WriteLine("A kihívott és a kihívó neve megegyezik!");
            }

            if (this.eletero <= 0 || kihivott.eletero <=0)
            {
                Console.WriteLine("Az egyik harcos életereje 0!");
            }

            kihivott.eletero -= this.Sebzes;

            if (kihivott.eletero>0)
            {
                this.eletero -= kihivott.Sebzes;
            }

            if (this.eletero > 0)
            {
                this.tapasztalat += 5;
            }
            else
            {
                kihivott.tapasztalat += 10;
            }
            if (kihivott.eletero > 0)
            {
                kihivott.tapasztalat += 5;
            }
            else
            {
                this.tapasztalat += 10;
            }

        }
        
        public void Gyogyul() {
            if (this.eletero <= 0)
            {
                this.eletero = this.maxEletero;
                this.tapasztalat = 0;
                //this.szint = 0;
            }
            else if(this.eletero < this.maxEletero)
            {
                this.eletero = this.eletero + 3 + this.szint;
            }

            if (this.eletero > this.maxEletero)
            {
                this.eletero = this.maxEletero;
            }

        }

        


    }
}
