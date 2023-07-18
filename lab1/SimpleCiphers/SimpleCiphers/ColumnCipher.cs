using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleCiphers.MainForm;

namespace SimpleCiphers
{
    internal class ColumnCipher : Cipher
    {

        
        public static string Run(string message, string userkey, OptionType type)
        {
            
            string key = Validation(userkey, usAlphabeth);
            if (key.Length == 0)
            {
                MessageBox.Show("KEY: doesn't contain english letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            ///<summary> 
            /// Get indexes to take columns in right order
            /// </summary>
            int key_len = key.Length;
            char[] chars = key.ToCharArray();
            Array.Sort(chars);
            int[] indexes = new int[key_len];
            Dictionary<int, int> keymap = new Dictionary<int, int>();
            string temp = key;
            for (int i = 0; i < key_len; i++)
            {
                int ind = temp.IndexOf(chars[i]);
                indexes[i] = ind + 1;
                keymap[i + 1] = ind;
                temp = temp.Insert(ind + 1, " ");
                temp = temp.Remove(ind, 1);
            }

            switch (type)
            {
                case OptionType.Encrypt: return EncryptColumnCipher(Validation(message, usAlphabeth), keymap);
                case OptionType.Decrypt: return DecryptColumnCipher(Validation(message, usAlphabeth), keymap);
                default: MessageBox.Show("ColumnCipher: Incorrect option"); return "Invalid Operation";
            }
        }

        private static string EncryptColumnCipher(string message, Dictionary<int, int> keymap)
        {
            StringBuilder result = new StringBuilder();
            int key_len = keymap.Count;

            ///<summary>
            /// на каждой новой итерации считываем номер нужного нам столбца.
            /// То есть в переменной curind будет лежать номер столбца, который надо считывать из таблицы столбцов.
            /// К примеру если у нас в keymap[1] лежит 3 => тогда это означает что мы берем 3-й столбец сперва
            /// </summary>
            for (int i = 1; i <= key_len; i++)
            {
                int curind = keymap[i];
               ///<summary>
               /// Мы идем по всему тексту с шагом в длину ключа, 
               /// таким образом мы всегда будем брать элемент из нужного нам столбца
               /// </summary>
                while (curind < message.Length)
                {
                    ///<param name="usAlphabeth">строка с алфавитом</param>
                    if (usAlphabeth.Contains(message[curind]))
                    {
                        result.Append(message[curind]);
                        curind += key_len;
                    }
                    else
                    {
                        curind++; //если не элемент алфавита то просто скипаем его
                    }
                }
            }
            return result.ToString();
        }

        private static string DecryptColumnCipher(string cipher, Dictionary<int, int> keymap)
        {
            int key_len = keymap.Count;
            char[] a = new char[cipher.Length];
            int aboba = 0;

            ///<summary>
            /// В обратном порядке => заполняем массив 'a' по столбцам, 
            /// ну то есть каждый k-ый элемент
            /// к примеру если у нас первым считывается 3-ий столбец, то после 1-ой итерации будет выглядеть как-то так:
            /// __a__l__i и тп.
            /// абоба это индекс элемента шифротекста, который нужно пристроить, желательно, даже очень надо сменить название переменной :)
            /// </summary> 
            for (int i = 1; i <= key_len; i++)
            {
                int curind = keymap[i];
                while (curind < a.Length && aboba < cipher.Length)
                {
                    if (usAlphabeth.Contains(cipher[aboba]))
                    {
                        a[curind] = cipher[aboba++];
                        curind += key_len;
                    }
                    else
                        aboba++;
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (var item in a)
            {
                result.Append(item);
            }
            return result.ToString();
        }

        
    }
}
