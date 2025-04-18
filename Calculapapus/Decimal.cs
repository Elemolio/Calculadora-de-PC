using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculapapus
{
    public class Decimal
    {
        public static string Sumar(string valor1, string valor2)
        {
            double numero1 = Convert.ToDouble(valor1);
            double numero2 = Convert.ToDouble(valor2);
            return (numero1 + numero2).ToString();
        }

        public static string Restar(string valor1, string valor2)
        {
            double numero1 = Convert.ToDouble(valor1);
            double numero2 = Convert.ToDouble(valor2);
            return (numero1 - numero2).ToString();
        }

        public static string Multiplicar(string valor1, string valor2)
        {
            double numero1 = Convert.ToDouble(valor1);
            double numero2 = Convert.ToDouble(valor2);
            return (numero1 * numero2).ToString();
        }

        public static string Dividir(string valor1, string valor2)
        {
            double numero1 = Convert.ToDouble(valor1);
            double numero2 = Convert.ToDouble(valor2);
            if (numero2 == 0)
                throw new DivideByZeroException("Error: División por cero.");
            return (numero1 / numero2).ToString();
        }
    }
}