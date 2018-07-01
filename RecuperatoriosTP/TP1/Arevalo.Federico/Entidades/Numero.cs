using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region ATRIBUTO

        public double _numero;

        #endregion

        #region PROPIEDAD

        public string SetNumero
        {
            set
            {
                this._numero = ValidarNumero(value);
            }
        }

        #endregion

        #region METODO

        private double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double returnValue);

            return returnValue;
        }

        public string BinarioDecimal(string binario)
        {
            int entero = 0;

            int numero;

            if (int.TryParse(binario, out numero))
            {
                for (int i = 1; i <= binario.Length; i++)
                {
                    entero += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
            }

            return entero.ToString();
        }

        public string DecimalBinario(string binario)
        {
            int numero;
            string returnValue = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    returnValue = (numero % 2).ToString() + returnValue;
                    numero = numero / 2;
                }
            }
            else
                returnValue = "Valor inválido";

            return returnValue;
        }

        public string DecimalBinario(double binario)
        {
            return this.DecimalBinario(binario.ToString());
        }
        #endregion

        #region CONSTRUCTORES

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero() : this(0)
        {

        }

        public Numero(string numero) : this(double.Parse(numero))
        {

        }

        #endregion

        #region SOBRECARGA DE OPERADORES

        public static double operator -(Numero num1, Numero num2)
        {
            return num1._numero - num2._numero;
        }

        public static double operator +(Numero num1, Numero num2)
        {
            return num1._numero + num2._numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            return num1._numero / num2._numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1._numero * num2._numero;
        }

        #endregion

    }
}
