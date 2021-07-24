using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Objetos
{
    public class IndumentariaEventArgs : EventArgs
    {
        private readonly Indumentaria indumentariaPasar;

        public IndumentariaEventArgs(Indumentaria indumentariaPasar)
        {
            this.indumentariaPasar = indumentariaPasar;
        }

        public Indumentaria IndumentariaObject
        {
            get { return indumentariaPasar; }
        }
    }
}
