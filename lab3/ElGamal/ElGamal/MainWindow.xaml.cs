using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using ElGamalC; 

namespace ElGamal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ElGamalCipher el = new ElGamalCipher();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string FilePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
               // message_text = File.ReadAllText(FilePath);   
                el.message_bytes = File.ReadAllBytes(FilePath);
                tbMessage.Text = GetSmallOutput(el.message_bytes);
            }
        }

        private string GetSmallOutput(string mes)
        {
            if (mes.Length > 100)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine(mes.Substring(0, 100));
                str.AppendLine("------------");
                str.AppendLine(mes.Substring(mes.Length - 100));
                return str.ToString();
            }
            else
                return mes;
        }
        private string GetSmallOutput(byte[]? bytes)
        {
            if (bytes != null)
            {
                const int OUTPUT_SIZE = 100;
                StringBuilder res = new StringBuilder();
                int len = bytes.Length;
                if (len > OUTPUT_SIZE * 2)
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (i < OUTPUT_SIZE || i > len - OUTPUT_SIZE)
                            res.Append(bytes[i].ToString() + " ");
                        else if (i == OUTPUT_SIZE)
                            res.Append("\n--------------\n");
                    }
                }
                else
                {
                    for (int i = 0; i < len / 2; i++)
                        res.Append(bytes[i].ToString() + " ");
                    res.Append("\n-----------\n");
                    for (int i = len / 2; i < len; i++)
                        res.Append(bytes[i].ToString() + " ");
                }
                return res.ToString();
            }
            else
                return "Byte array is empty";
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string saveFilePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                saveFilePath = saveFileDialog.FileName;
                File.WriteAllBytes(saveFilePath, el.cipher_bytes);
            }
        }


        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {

            if (el.Validation() && el.message_bytes != null)
            {
                tbCipher.Text = $"p: {el.p}\ng: {el.g}\nx: {el.x}\nk: {el.k}\ny: {el.y}\na: {el.a}\nb: {el.b}\n";
                tbCipher.Text += GetSmallOutput(el.Encryption());
            }
        }


        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {

            if (el.Validation() && el.message_bytes != null)
            {
                tbCipher.Text = $"p: {el.p}\ng: {el.g}\nx: {el.x}\nk: {el.k}\ny: {el.y}\na: {el.a}\nb: {el.b}\n";
                tbCipher.Text += GetSmallOutput(el.Decryption());
            }
        }

        private void tbP_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbP.Text, out el.p);
            el.SetSize(el.p);
            
        }
        private int GetSize(int p)
        {
            const uint one_byte_max = Byte.MaxValue;
            const uint two_byte_max = UInt16.MaxValue;
            const uint four_byte_max = UInt32.MaxValue;
            return (uint)p switch
            {
                <= one_byte_max => 1,
                <= two_byte_max => 2,
                <= four_byte_max => 4
            };
        }

        private void tbX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbX.Text, out el.x);
        }
        private void tbK_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbK.Text, out el.k);
        }
        private void tbP_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            cbG.Items.Clear();
            var g_roots = el.GetGRoots();
            MessageBox.Show(g_roots.Count().ToString());
            if(g_roots != null)
            {
                /*for(int i=0; i<100; i++)
                    cbG.Items.Add(g_roots[i]);
                for (int i = g_roots.Count - 1; i >= g_roots.Count - 100; i--)
                    cbG.Items.Add(g_roots[i]);*/
                foreach (var root in g_roots)
                    cbG.Items.Add(root);
            }
          //  cbG.Items.Remove(el.p);
        }


        private void tbCipher_TextChanged(object sender, TextChangedEventArgs e)
        {
            el.SetCipherText(tbCipher.Text);
        }
        private void tbMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            el.SetMessageText(tbMessage.Text);
        }

        private void cbG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                el.g = el.g_list[cbG.SelectedIndex];
            }
            catch { }
        }

        
    }
}
