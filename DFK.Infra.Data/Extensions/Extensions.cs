using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Infra.Data.Extensions
{
    public static class Extensions
    {
        public static int ConvertDecimalToLong(this decimal argument)
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("pt-BR");
                var value = argument.ToString("N2", culture);
                value = value.Replace(".", "").Replace(",", "");

                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
