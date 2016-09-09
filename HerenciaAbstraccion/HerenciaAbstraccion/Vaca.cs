using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaAbstraccion
{
    class Vaca : Mamifero, INecesidadesBiologicas 
    {
        public double TamanioCuerno { get; set; }

        public Vaca() { }

        public Vaca(int numeroPatas, string color) :base (numeroPatas, color)
        {
            base.NumeroPatas = numeroPatas;
            base.Color = color;
        }

        public Vaca(int numeroPatas, string color, double TamanioCuerno): base (numeroPatas, color)
        {
            this.TamanioCuerno = TamanioCuerno;

        }
        public override void EmitirSonido()
        {
            Console.WriteLine("Muuuu muuu muuuuu");
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
