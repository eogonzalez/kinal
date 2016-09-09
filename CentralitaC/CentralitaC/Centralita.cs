using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaC
{
    class Centralita
    {
        private double _Acumulador;
        private int _Contador;

        public int GetTotalLlamadas()
        {
            return _Contador;
        }

        public double GetTotalFacturacion()
        {
            return _Acumulador;
        }

        public void RegistrarLlamada(Llamada Registro)
        {
            _Contador = _Contador + 1;
            _Acumulador = _Acumulador + Registro.CalcularPrecio();
        }
    }
}
