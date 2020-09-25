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
        private int alapEletero;
        private int alapSebzes;

        public Harcos(string nev, int szint, int tapasztalat, int alapEletero, int alapSebzes)
        {
            this.nev = nev;
            this.szint = szint;
            this.tapasztalat = tapasztalat;
            this.alapEletero = alapEletero;
            this.alapSebzes = alapSebzes;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int AlapEletero { get => alapEletero; set => alapEletero = value; }
        public int AlapSebzes { get => alapSebzes; set => alapSebzes = value; }
    }
}
