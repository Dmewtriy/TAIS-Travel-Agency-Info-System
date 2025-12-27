using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIS__Tourist_Agency_Info_System_.Entities.Enums
{
    public enum TypeEvent
    {
        /// <summary>
        /// Прием
        /// </summary>
        Hiring,

        /// <summary>
        /// Перевод
        /// </summary>
        Transfer,

        /// <summary>
        /// Увольнение
        /// </summary>
        Dismissal,
    }

    public static class TypeEventExtensions
    {
        public static string GetStringByEnum(this TypeEvent value)
        {
            switch (value)
            {
                case TypeEvent.Hiring: return "Прием";
                case TypeEvent.Transfer: return "Перевод";
                case TypeEvent.Dismissal: return "Увольнение";
            }
            return "";
        }

        public static TypeEvent GetEnumByString(string value)
        {
            switch (value.ToLower())
            {
                case "прием": return TypeEvent.Hiring;
                case "перевод": return TypeEvent.Transfer;
                case "увольнение": return TypeEvent.Dismissal;
            }
            throw new ArgumentException("Такого состояния не существует");
        }
    }
}
