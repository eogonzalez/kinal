using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaAbstraccion
{
    class Perro : Mamifero, INecesidadesBiologicas
    {
        public double TamanioColmillo { get; set; }

        public Perro() { }

        public Perro(int numeroPatas, string color) : base (numeroPatas,color)
        {
            base.NumeroPatas = numeroPatas;
            base.Color = color;
        }

        public Perro(int numeroPatas, string color, double TamanioColmillo) : base (numeroPatas, color)
        {
            this.TamanioColmillo = TamanioColmillo;
        }

        public override void EmitirSonido()
        {
            Console.WriteLine("guaauu gauuu");
        }

        public void Caminar()
        {
            Console.WriteLine("Caminando...");
        }

        public void Dormir()
        {
            Console.WriteLine("Durmiendo...");
        }

        public void Comer()
        {
            Console.WriteLine("Comiendo...");
        }
    }
}
