using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCiphers
{
    internal abstract class Cipher
    {
        public enum OptionType
        {
            Encrypt, Decrypt
        }

        protected const string usAlphabeth = "abcdefghijklmnopqrstuvwxyz";
        protected const string ruAlphabeth = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        protected const string numAlphabeth = "0123456789";
       
        protected static string Validation(string text, string Alphabeth)
        {
            StringBuilder result = new StringBuilder();
            text = text.ToLower();
            for (int i = 0; i < text.Length; i++)
            {
                if (Alphabeth.Contains(text[i]))
                    result.Append(text[i]);
            }
            return result.ToString();
        }

        
    }
}
