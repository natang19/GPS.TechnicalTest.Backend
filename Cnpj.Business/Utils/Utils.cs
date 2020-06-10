using System;
using System.Collections.Generic;
using System.Text;

namespace Cnpj.Business.Utils
{
    public static class Utils
    {
        public static string ApenasNumeros(this string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
