using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Printing.IndexedProperties;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadCipher
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private const byte BYTE_LEN = 8;

        public byte[] FileBytes;
        public StringBuilder strMessage = new StringBuilder();
        public long MessageLen;
        public byte[] CipherBytes;
        public StringBuilder strCipher = new StringBuilder();
        public long CipherLen;

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();
            strMessage.Clear();
            if (openFileDialog.ShowDialog() == true)
            {
                FileBytes = File.ReadAllBytes(openFileDialog.FileName);
                for(int i=0; i<FileBytes.Length;i++) 
                {
                    if (i <= 100 || (FileBytes.Length - i < 100))
                    {
                        strMessage.Append(Convert.ToString(FileBytes[i], 2).PadLeft(BYTE_LEN, '0'));
                        
                        if (i == 100)
                            strMessage.Append("\n....\n");
                    }
                }
                MessageLen = FileBytes.LongLength;

                string message_text = strMessage.ToString();
                message_text = Validation(message_text);
                TbMessage.Text = message_text;
            }
        }

        public string Validation(string message)
        {
            Regex regex = new Regex(@"[^01]*$");
            return regex.Replace(message, "");
        }




        private string GetStringByte(int b)
        {
            StringBuilder s = new StringBuilder();
            int a;
            for(int i=0; i< BYTE_LEN; i++)
            {
                a = b & 1;
                b = b >> 1;
                s.Append(a.ToString());
            }
            return new string(s.ToString().Reverse().ToArray());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllBytes(saveFileDialog.FileName,CipherBytes);
            } 
        }

        private string ValidXors(string s) => s.Replace("\r\n", "");
            
        

        private void btnCipher_Click(object sender, RoutedEventArgs e)
        {
            Register lfsr;
            if (TbXors.Text != string.Empty)
            {
                string[] Xors = ValidXors(TbXors.Text).Split(", ");
                int[] temp = new int[Xors.Length];
                for (int i = 0; i < temp.Length; i++)
                    temp[i] = Convert.ToInt32(Xors[i]);
                 lfsr = new Register(TbKey.Text, temp);
            }
            else
                lfsr = new Register(TbKey.Text);

            TbKey.Text = lfsr.Key;
            TbCipher.Text = "";
            int ind = 0;
            int byte_ind = 0;
            CipherBytes = new byte[MessageLen];
            strCipher.Clear();
            for(int i=0; i<MessageLen * BYTE_LEN; i+= BYTE_LEN)
            {
                int a = lfsr.GenerateByte();
                byte b = FileBytes[ind++];                
                byte c = (byte)(a ^ b);

                //MessageBox.Show($"{a} xor {b} = {c}");
                if (i <= 100 * BYTE_LEN || (MessageLen * BYTE_LEN - i < 100 * BYTE_LEN))
                {
                    strCipher.Append(Convert.ToString(c, 2).PadLeft(BYTE_LEN, '0'));
                    /*TbKey.AppendText(Convert.ToString(a,2).PadLeft(BYTE_LEN, '0'));
                    TbKey.AppendText("_");*/
                    if (i == 100 * BYTE_LEN)
                        strCipher.Append("\n....\n");
                }
                CipherBytes[byte_ind++] = c;
            }
            string cipher_text = strCipher.ToString();
            cipher_text = Validation(cipher_text);
            TbCipher.Text = cipher_text;
            MessageBox.Show("Encryption has finished", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TbMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
