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

    }
}
