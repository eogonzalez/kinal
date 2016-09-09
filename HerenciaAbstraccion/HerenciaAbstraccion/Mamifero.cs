using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaAbstraccion
{
    abstract class Mamifero
    {
        private int numeroPatas;
        private string color;

        public Mamifero() { }
        
        public Mamifero(int numeroPatas, string color)
        {
            this.numeroPatas = numeroPatas;
            this.color = color;
        }

        public int NumeroPatas
        {
            get { return numeroPatas;  }
            set
            {
                if (value > 0)
                {
                    numeroPatas = value;
                }
            }
        }

        public string Color
        {
            get { return color;  }
            set { color = value;  }
        }

        public abstract void EmitirSonido();

    }
}
