using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaC
{
    public partial class Llamada
    {
        public string NumeroOrigen { get; set; }
        public string NumeroDestino { get; set; }
        public double Duracion { get; set; }
        public string Compania { get; set; }

        public Llamada() { }

        public Llamada(string NumeroOrigen, string NumeroDestino, double Duracion)
        {
            this.NumeroOrigen = NumeroOrigen;
            this.NumeroDestino = NumeroDestino;
            this.Duracion = Duracion;
        }

        public void CentralitaC(string NumeroOrigen, string NumeroDestino, double Duracion, string Compania)
        {
            this.NumeroOrigen = NumeroOrigen;
            this.NumeroDestino = NumeroDestino;
            this.Duracion = Duracion;
            this.Compania = Compania;
        }

        public abstract double CalcularPrecio();
    }
}
