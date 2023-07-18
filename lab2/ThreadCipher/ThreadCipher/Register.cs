using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThreadCipher
{
    public class Register
    {
        private const byte BYTE_LEN = 8;
        private int[] KeyBytes;
        public string Key;

        private int[] XorPositions;
        private int StartKeyLen = 0;
        public Register(string key, params int[] xors)
        {
            StartKeyLen = xors.Max();
            XorPositions = new int[xors.Length];
            for (int i = 0; i < xors.Length; i++)
                XorPositions[i] = xors[i] - 1;


            KeyBytes = FillKey(key);
        }
        public Register(string key) : this(key, new int[] { 13, 33 })
        {}

        private int CountedXors
        {
            get
            {
                int result = KeyBytes[XorPositions[0]];
                for(int i = 1; i < XorPositions.Length; i++)
                {
                    result = result ^ KeyBytes[XorPositions[i]];
                }

                return result;
            }
        }
        public int GenerateByte()
        {
            int KLen = KeyBytes.Length;
            int keyB = 0;
            int new_bit = 0;

            for (int j = 0; j < BYTE_LEN; j++)
            {
                keyB = keyB << 1;
                keyB |= KeyBytes[KLen - 1];
                new_bit = CountedXors; //KeyBytes[12] ^ KeyBytes[32];
                for (int i = KLen - 1; i > 0; i--)
                {
                    KeyBytes[i] = KeyBytes[i - 1];
                }
                KeyBytes[0] = new_bit;
            }
            return keyB;
        }

        private int[] FillKey(string key)
        {
            key = Validation(key);
            while (key.Length < StartKeyLen)
            {
                key += "1";
            }
            Key = key;
            

            int[] result = new int[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                result[i] = key[i] - '0';
            }
            return result;
        }

        public string Validation(string message)
        {
            Regex regex = new Regex(@"[^01]*$");
            return regex.Replace(message, "");
        }

    }
}
