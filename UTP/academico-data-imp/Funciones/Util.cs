using System;
using System.Collections.Generic;
using System.Text;

namespace academico_data_imp.Funciones
{
    public class Util
    {
    }

    public static class Conversion
    {
        public static object ToDBNull(this Int32? value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(this Int16? value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(this Int64? value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(this decimal? value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(this string value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        public static object ToDBNull(this DateTime? value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }

        internal static string Cadena(this System.Data.IDataReader dr, string campo, string valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : dr[campo].ToString().Trim();
        }

        internal static DateTime? Fecha(this System.Data.IDataReader dr, string campo, DateTime? valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : (DateTime?)Convert.ToDateTime(dr[campo]);
        }

        internal static Int32? Entero(this System.Data.IDataReader dr, string campo, Int32? valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : (Int32?)Convert.ToInt32(dr[campo]);
        }

        internal static Int64? Entero64(this System.Data.IDataReader dr, string campo, Int64? valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : (Int64?)Convert.ToInt64(dr[campo]);
        }

        internal static Int16? EnteroCorto(this System.Data.IDataReader dr, string campo, Int16? valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : (Int16?)Convert.ToInt16(dr[campo]);
        }

        internal static bool Boleano(this System.Data.IDataReader dr, string campo, bool valor = false)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : Convert.ToBoolean(dr[campo]);
        }

        internal static Decimal? Decimal(this System.Data.IDataReader dr, string campo, Decimal? valor = null)
        {
            return System.Convert.IsDBNull(dr[campo]) ? valor : (Decimal?)Convert.ToDecimal(dr[campo]);
        }
    }
}
