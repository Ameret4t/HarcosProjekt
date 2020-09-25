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
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero; }
        public int Sebzes { get => alapSebzes + szint; }
        public int AlapSebzes { get => alapSebzes; }

        public int maxEletero { get => alapEletero + (szint * 3); }

        public int szintLepeshez { get =>  10 + szint * 5; }

        

        public override string ToString()
        {
            return String.Format("{0} - LVL: {1} - EXP: {2} - HP: {3} - DMG: {4}",nev, szint, tapasztalat, eletero, Sebzes);
        }

        public void megKuzd(Harcos Kihivott) {
            if (this.nev == Kihivott.nev )
            {
                Console.WriteLine("A két harcos neve megyezik!");
            }
            else if (this.eletero == 0 || Kihivott.eletero == 0)
            {
                Console.WriteLine("A harcos életereje 0!");
            }
            bool kihivoTamad = true;

            while (this.eletero > 0 && Kihivott.eletero > 0)
            {
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
            }

           
        }

        public void Gyogyul() {
            if (this.eletero == 0)
            {
                this.eletero = this.maxEletero;
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
