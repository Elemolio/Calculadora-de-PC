using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculapapus
{
    public class Binario
    {
        public static string Sumar(string valor1, string valor2)
        {
            int numero1 = Convert.ToInt32(valor1, 2);
            int numero2 = Convert.ToInt32(valor2, 2);
            int resultado = numero1 + numero2;
            return Convert.ToString(resultado, 2);
        }

        public static string Restar(string valor1, string valor2)
        {
            int numero1 = Convert.ToInt32(valor1, 2);
            int numero2 = Convert.ToInt32(valor2, 2);
            int resultado = numero1 - numero2;
            return Convert.ToString(resultado, 2);
        }

        public static string Multiplicar(string valor1, string valor2)
        {
            int numero1 = Convert.ToInt32(valor1, 2);
            int numero2 = Convert.ToInt32(valor2, 2);
            int resultado = numero1 * numero2;
            return Convert.ToString(resultado, 2);
        }

        public static string Dividir(string valor1, string valor2)
        {
            int numero1 = Convert.ToInt32(valor1, 2);
            int numero2 = Convert.ToInt32(valor2, 2);
            if (numero2 == 0)
                throw new DivideByZeroException("Error: División por cero.");
            int resultado = numero1 / numero2;
            return Convert.ToString(resultado, 2);
        }
    }
}

