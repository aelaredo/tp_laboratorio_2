using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar  (Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            // usar un tryparse
            char operadorValidado = ValidarOperador(Convert.ToChar(operador));

            switch (operadorValidado)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }

            return resultado;
        }


        private static char ValidarOperador(char operador)
        {
            char operadorValidado = ' ';

            if (operador != '+' && operador != '-' && operador != '/' && operador != '*' && operador != ' ')
            {
                operadorValidado = '+';
            }else
            {
                operadorValidado = operador;
            }

            return operadorValidado;
        }

        
    }
}
