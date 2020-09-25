using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            this.eletero = maxEletero;
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
            
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero; }
        public int Sebzes { get => alapSebzes + szint; }
        public int AlapSebzes { get => alapSebzes; }
        
        public int maxEletero { get => alapEletero; }
        public int szintLepeshez { get =>  10 + szint * 5; }

        public void toString() {
            Console.WriteLine("{0} - LVL: {1} - EXP {2}");
        }

        public override string ToString()
        {
            return String.Format("{0} - LVL: {1} - EXP: {2} - HP: {3} - DMG: {4}",nev, szint, tapasztalat, eletero, Sebzes);
        }

        public void megKuzd(Harcos Kihivo, Harcos Kihivott) {
            if (Kihivo == Kihivott )
            {
                Console.WriteLine("A két harcos neve megyezik!");
            }
            else if (Kihivo.eletero == 0 || Kihivott.eletero == 0)
            {
                Console.WriteLine("A harcos életereje 0!");
            }
            bool kihivoTamad = true;

            while (Kihivo.eletero != 0 && Kihivott.eletero != 0)
            {
                if (kihivoTamad)
                {
                    Kihivott.eletero = Kihivott.eletero - Kihivo.Sebzes;
                }
                else { 
                    Kihivo.eletero = Kihivo.eletero - Kihivott.Sebzes; 
                }

                kihivoTamad = !kihivoTamad;

                if (Kihivo.eletero != 0)
                {
                    Kihivo.tapasztalat = Kihivo.Tapasztalat + 5;
                }

                if (Kihivott.eletero != 0)
                {
                    Kihivott.tapasztalat = Kihivott.Tapasztalat + 5;
                }

                if (Kihivo.eletero == 0)
                {
                    Kihivott.tapasztalat = Kihivott.Tapasztalat + 10;
                }

                if (Kihivott.eletero != 0)
                {
                    Kihivo.tapasztalat = Kihivo.Tapasztalat + 10;
                }
            }

           
        }


    }
}
