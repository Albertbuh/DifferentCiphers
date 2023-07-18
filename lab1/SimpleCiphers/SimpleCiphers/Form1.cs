using System.Text;

namespace SimpleCiphers
{
    public partial class MainForm : Form
    {
        private string plaintext = "";
        private string ciphertext = "";
        private string key = "";
        private const string usAlphabeth = "abcdefghijklmnopqrstuvwxyz";
        private const string ruAlphabeth = "àáâãäå¸æçèéêëìíîïðñòóôõö÷øùúûüýþÿ";
        private const string numAlphabeth = "0123456789";
        
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(fileName);

            plaintext = fileText;
            tbM.Text = plaintext;

        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(fileName, tbC.Text);
            MessageBox.Show("File saved");
        }


        private void rbEncrypt_Click(object sender, EventArgs e)
        {
            btnDo.Text = "Encrypt";
        }

        private void rbDecrypt_Click(object sender, EventArgs e)
        {
            btnDo.Text = "Decrypt";
        }

        private void cbCipherName_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { cbCipherName.Select(0, 0); }));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbCipherName.BeginInvoke(new Action(() => { cbCipherName.Select(0, 0); }));
        }


        private void btnDo_Click(object sender, EventArgs e)
        {
            int chiper_ind = cbCipherName.SelectedIndex;
            switch (chiper_ind)
            {
                case 0:
                    {
                        if (rbEncrypt.Checked)
                            ciphertext = ColumnCipher.Run(plaintext, key, Cipher.OptionType.Encrypt);
                        else
                            ciphertext = ColumnCipher.Run(plaintext, key, Cipher.OptionType.Decrypt);
                        tbC.Text = ciphertext;
                        break;
                    }
                case 1:
                    {
                        if (rbEncrypt.Checked)
                            ciphertext = VigenereCipher.Run(plaintext, key, Cipher.OptionType.Encrypt);
                        else
                            ciphertext = VigenereCipher.Run(plaintext, key, Cipher.OptionType.Decrypt);
                        tbC.Text = ciphertext;
                        break;
                    }
                default:
                    MessageBox.Show("Choose the cipher", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
            }
        }

        
        private void tbM_TextChanged(object sender, EventArgs e)
        {
            plaintext = tbM.Text;
        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {
            key = tbKey.Text;
        }


      
        /*public string ColumnCipher(string message, string userkey, OptionType type)
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

            switch (type) {
                case OptionType.Encrypt:  return EncryptColumnCipher(Validation(message, usAlphabeth), keymap);
                case OptionType.Decrypt: return DecryptColumnCipher(Validation(message, usAlphabeth), keymap);
                default: MessageBox.Show("ColumnCipher: Incorrect option");  return "Invalid Operation";
            }
        }

        public string EncryptColumnCipher(string message, Dictionary<int,int> keymap)
        {
            StringBuilder result = new StringBuilder();
            int key_len = keymap.Count;
            for (int i = 1; i <= key_len; i++)
            {
                int curind = keymap[i];
                while (curind < message.Length)
                {
                    if (usAlphabeth.Contains(message[curind]))
                    {
                        result.Append(message[curind]);
                        curind += key_len;
                    }
                    else
                    {
                        curind++;
                    }
                }
            }
            return result.ToString();
        }

        public string DecryptColumnCipher(string cipher, Dictionary<int, int> keymap)
        {
            int key_len = keymap.Count;
            char[] a = new char[cipher.Length];
            int aboba = 0;
            for(int i=1; i<=key_len; i++)
            {
                int curind = keymap[i];
                while(curind < a.Length && aboba < cipher.Length)
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
        }*/

        /*public string Validation(string text, string Alphabeth)
        {
            StringBuilder result = new StringBuilder();
            text = text.ToLower();
            for(int i=0; i<text.Length; i++)
            {
                if (Alphabeth.Contains(text[i]))
                    result.Append(text[i]);
            }
            return result.ToString();
        }*/


        /* public string VigenereCipher(string message, string userkey, OptionType type)
         {
             string tempkey = Validation(userkey, ruAlphabeth);
             if (tempkey.Length == 0)
             {
                 MessageBox.Show("KEY: doesn't contain english letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                 case OptionType.Encrypt:  return EncryptVigenereCipher(message, key);
                 case OptionType.Decrypt:  return DecryptVigenereCipher(message, key);
                 default: MessageBox.Show("VigenereCipher: incorrect option"); return "invalid option (choose Encrypt or Decrypt your text)";
             }

         }

         public string DecryptVigenereCipher(string cipher, string key)
         {
             StringBuilder result = new StringBuilder();
             int key_len = key.Length;
             for(int i = 0; i < key_len; i++)
             {
                 int old_char = ruAlphabeth.IndexOf(key[i]);
                 old_char = ruAlphabeth.IndexOf(cipher[i]) - old_char;

                 result.Append(old_char >= 0 ? ruAlphabeth[old_char] : ruAlphabeth[ruAlphabeth.Length+old_char]);
             }
             return result.ToString();
         }

         public string EncryptVigenereCipher(string message, string key)
         {
             StringBuilder result = new StringBuilder();
             int key_len = key.Length;
             for (int i = 0; i < key_len; i++)
             {
                 int new_char = ruAlphabeth.IndexOf(key[i]);
                 new_char += ruAlphabeth.IndexOf(message[i]);
                 new_char %= ruAlphabeth.Length;
                 result.Append(ruAlphabeth[new_char]);
             }
             return result.ToString();
         }


         private string CesarCipher(string mes, int key, string alphabeth)
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
        */

    }
}