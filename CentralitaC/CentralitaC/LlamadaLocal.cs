using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaC
{
    class LlamadaLocal : Llamada
    {
        private double Precio { get; set; } = 1.0;
        
        public LlamadaLocal() { new Llamada(); }

        public LlamadaLocal(string NumeroOrigen, string NumeroDestino, double Duracion, double Precio)
        {
            new Llamada(NumeroOrigen, NumeroDestino, Duracion);
            this.Precio = Precio
        }

        public override double CalcularPrecio()
        {
            Double Resultado = 0.00;
            Resultado = Precio * base.Duracion;
            return Resultado;
        }

        public override string ToString()
        {
            string Resultado = string.Empty;

            Resultado = "Se registro una llamada local " +
                " Numero Origen: "+NumeroOrigen+
                " Numero Destino: "+NumeroDestino+
                " Costo: " + CalcularPrecio() +
                " Duracion: " + Duracion ;

            return Resultado;
        }
    }
}
