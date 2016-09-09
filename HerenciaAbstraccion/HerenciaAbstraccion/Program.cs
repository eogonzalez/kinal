using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaAbstraccion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creando coleccion de objetos
            List<Mamifero> ListaAnimales = new List<Mamifero>();

            Perro Damian = new Perro(4, "Blanco", 0.4);
            Perro Duke = new Perro(4, "Negro", 0.6);

            Vaca Maggie = new Vaca(4, "Blanco", 18.6);
            Vaca SraCalloway = new Vaca(4, "Negro", 6.0);

            ListaAnimales.Add(Damian);
            ListaAnimales.Add(Duke);
            ListaAnimales.Add(Maggie);
            ListaAnimales.Add(SraCalloway);

            foreach (Mamifero Elemento in ListaAnimales)
            {
                //Console.WriteLine(Elemento.GetType());
                //Console.WriteLine(Elemento.GetType().ToString().LastIndexOf("."));

                int inicio = Elemento.GetType().ToString().LastIndexOf(".");
                int caracteres = Elemento.GetType().ToString().Length - inicio;

                Console.WriteLine(Elemento.GetType().ToString().Substring(inicio+1,caracteres-1)); 

                if (Elemento is Perro)
                {
                    Console.WriteLine("Tamanio Comillo {0} ", ((Perro)Elemento).TamanioColmillo);
                }
                else if (Elemento is Vaca)
                {
                    Console.WriteLine("Tamanio Cuerno {0}", ((Vaca)Elemento).TamanioCuerno);
                }

                Elemento.EmitirSonido();
            }
            Console.ReadLine();
        }
    }
}
