using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndumentariasExceptions
{
    public class IndumentariasExceptionsRepetida : Exception
    { 
        public IndumentariasExceptionsRepetida(string mensaje):base(mensaje)
        {
        }

        public IndumentariasExceptionsRepetida(string mensaje, Exception e) : base(mensaje, e)
        {
        }

    }

    public class IndumentariasExceptionsNombreErroneo : Exception
    {
        public IndumentariasExceptionsNombreErroneo(string mensaje):base(mensaje)
        {
        }

        public IndumentariasExceptionsNombreErroneo(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }

    public class IndumentariasExceptionsPrecioErroneo : Exception
    {
        public IndumentariasExceptionsPrecioErroneo(string mensaje) : base(mensaje)
        {
        }

        public IndumentariasExceptionsPrecioErroneo(string mensaje, Exception e) : base(mensaje, e)
        {
        }
    }



    public class IndumentariasExceptionsIndumentariaNoInstanciada : Exception
    {
        public IndumentariasExceptionsIndumentariaNoInstanciada(string mensaje) : base(mensaje)
        {

        }

        public IndumentariasExceptionsIndumentariaNoInstanciada(string mensaje , Exception e): base(mensaje, e)
        {
            
        }
    }

    public class IndumentariasExceptionsErrorAlGenerarArchivo : Exception
    {
        public IndumentariasExceptionsErrorAlGenerarArchivo(string mensaje, Exception e) : base(mensaje, e)
        {

        }
    }

}
