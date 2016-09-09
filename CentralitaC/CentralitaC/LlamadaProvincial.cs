using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaC
{
    class LlamadaProvincial : Llamada
    {
        public double PrecioUno { get; set; }
        public double PrecioDos { get; set; }
        public double PrecioTres { get; set; }
        public int Franja { get; set; }

        public LlamadaProvincial() { new Llamada(); }

        public LlamadaProvincial(string NumeroOrigen, string NumerdoDestino, double PrecioUno, double PrecioDos, double PrecioTres, int Franja)
        {
            new Llamada(NumeroOrigen, NumeroDestino, Duracion);

            this.PrecioUno = PrecioUno;
            this.PrecioDos = PrecioDos;
            this.PrecioTres = PrecioTres;
            this.Franja = Franja;
        }

        public LlamadaProvincial(string NumeroOrigen, string NumeroDestino, double Duracion, int Franja)
        {
            new Llamada(NumeroOrigen, NumeroDestino, Duracion);
            this.Franja = Franja;
        }

        public override double CalcularPrecio()
        {
            double Resultado = 0.00;

            if (Franja == 1)
            {
                Resultado = PrecioUno * Duracion;
            }
            else if (Franja == 2)
            {
                Resultado = PrecioDos * Duracion;
            }
            else if (Franja == 3)
            {
                Resultado = PrecioTres * Duracion;
            }

            return Resultado;
        }

        public override string ToString()
        {
            string Resultado = string.Empty;

            Resultado = "Se registro una llamada departamental " +
                " Numero Origen: " + NumeroOrigen +
                " Numero Destino: " + NumeroDestino +
                " Costo: " + CalcularPrecio() +
                " Duracion: " + Duracion;

            return Resultado;
        }
    }
}
