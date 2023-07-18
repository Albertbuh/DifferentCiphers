using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleCiphers.MainForm;

namespace SimpleCiphers
{
    internal class VigenereCipher : Cipher
    { 
        public static string Run(string message, string userkey, OptionType type)
        {
            string tempkey = Validation(userkey, ruAlphabeth);
            if (tempkey.Length == 0)
            {
                MessageBox.Show("KEY: doesn't contain russian letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            message = Validation(message, ruAlphabeth);
            int key_len = tempkey.Length;
            int mes_len = message.Length;
            string key = "";

            while (key.Length < mes_len - mes_len % key_len)
            {
                key += tempkey;
                tempkey = CesarCipher(tempkey, 1, ruAlphabeth);
            }
            key += tempkey.Substring(0, mes_len % key_len);

            switch (type)
            {
                case OptionType.Encrypt: return EncryptVigenereCipher(message, key);
                case OptionType.Decrypt: return DecryptVigenereCipher(message, key);
                default: MessageBox.Show("VigenereCipher: incorrect option"); return "invalid option (choose Encrypt or Decrypt your text)";
            }

        }

        private static string DecryptVigenereCipher(string cipher, string key)
        {
            StringBuilder result = new StringBuilder();
            int key_len = key.Length;

            ///<summary>
            /// Сперва глянь шифрование, потом это
            /// ну на божьем слове работает
            /// берем наш шифротекст, отнимаем значение ключа (По таблице к первой строчке крч идем)
            /// а потом божье слово (если всё ок с индексом(он получается больше нуля, то есть буква шифротекста больше ключа) то берем его,
            /// если же меньше, то с конца идем просто (то есть от длины алфавита отнимаем наше значение (тут old_char < 0)!!!)
            /// P.S название old_char лучше сменить
            /// </summary>
            for (int i = 0; i < key_len; i++)
            {
                int old_char = ruAlphabeth.Length + ruAlphabeth.IndexOf(cipher[i]) - ruAlphabeth.IndexOf(key[i]);
                old_char %= ruAlphabeth.Length;

                result.Append(ruAlphabeth[old_char]);
            }
            return result.ToString();
        }

        private static string EncryptVigenereCipher(string message, string key)
        {
            StringBuilder result = new StringBuilder();
            int key_len = key.Length;
            ///<summary>
            /// Надо представить таблицу подстановки в голове... представил? Погнали дальше
            /// мы берем наш индекс ключа в алфавите -- это наш столбце, спускаемся вниз по таблице прямо к нашей букве
            /// дальше сдвигаемся вправо до буквы в тексте
            /// и финальным штрихом делаем мод, чтобы у нас не получился выход за границы массива (для примера можно глянуть случаи где key[i] = z, message[i] = b => z+b = ?)
            /// </summary>
            for (int i = 0; i < key_len; i++)
            {
                int new_char = ruAlphabeth.IndexOf(key[i]);
                new_char += ruAlphabeth.IndexOf(message[i]);
                new_char %= ruAlphabeth.Length;
                result.Append(ruAlphabeth[new_char]);
            }
            return result.ToString();
        }


        private static string CesarCipher(string mes, int key, string alphabeth)
        {
            StringBuilder result = new StringBuilder();
            int al_len = alphabeth.Length;
            int ind = 0;
            foreach (char letter in mes)
            {
                ind = alphabeth.IndexOf(letter) + key;
                ind = ind % al_len;
                result.Append(alphabeth[ind]);
            }
            return result.ToString();
        }

    }
}
