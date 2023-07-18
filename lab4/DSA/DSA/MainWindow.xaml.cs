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

namespace DSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int h0 = 100;
        public int q;
        public int p;
        public int g, h;
        public int x, y;
        public int k;
        public int r, s, v = 0;
        public byte[] messageBytes;
        public string? filePath;
        public int qSize = 2;
        public MainWindow()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Check if number is prime
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool IsPrimeNumber(int num)
        {
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// x^z mod m = ?
        /// </summary>
        /// <returns></returns>
        private int PowMod(int x, int z, int m)
        {
            int res = 1;
            while (z != 0)
            {
                while (z % 2 == 0)
                {
                    z >>= 1; //z = z div 2
                    x = (x * x) % m;
                }
                z = z - 1;
                res = (res * x) % m;
            }
            return res;
        }

    
        private bool DsaValidation()
        {
            if(!IsPrimeNumber(q))
                MessageBox.Show($"Invalid Q argument (please, set prime number)",
                   "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if ((p - 1) % q != 0)
                MessageBox.Show($"Invalid P argument (please,put number such P that p-1/q=n where n is whole number)",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (!IsPrimeNumber(p))
                MessageBox.Show($"Invalid P argument (please,put prime number to P argument",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (h <= 1 || h >= p - 1)
                MessageBox.Show($"Invalid H argument (please, set number in (1, {p - 1})",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (g <= 1)
                MessageBox.Show($"Invalid G argument (try h=2, it works almost always)",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else if (x <= 0 || x >= q)
                MessageBox.Show($"Invalid X argument (please, set number in (0, {q})",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (k <= 0 || k >= q)
                MessageBox.Show($"Invalid K argument (please, set number in (0, {q})",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(filePath == null)
                MessageBox.Show($"Choose file before",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                return true;
            return false;
        }
        /// <summary>
        /// Return array of bytes from Int value
        /// </summary>
        /// <param name="num"></param>
        /// <param name="size"></param>
        /// <returns>bytes[size-1] = 1-8bits, bytes[size-2] = 9-16[bits], bytes[size-3] = 17-24bits, bytes[size-4] = 25-32bits</returns>
        private byte[] GetBytes(int num, int size)
        {
            byte[] bytes = new byte[size];
            for (int i = size-1; i >= 0; i--)
            {
                bytes[i] = (byte)num;
                num >>= 8;
            }
            return bytes;
        }


        public void CreateSignature()
        {
            g = PowMod(h, (p - 1) / q, p);
            y = PowMod(g, x, p);
            int hash = h0;
            if (DsaValidation())
            {
                hash = CountHash(messageBytes);

                r = PowMod(g, k, p);
                r = r % q;
                s = (PowMod(k, q - 2, q) * (hash + x * r)) % q;

                if (r * s == 0)
                    MessageBox.Show($"Signature is 0, please try another K value",
                        "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                   // qSize = 1;
                    byte[] bytesR = GetBytes(r, qSize);
                    byte[] bytesS = GetBytes(s, qSize);
                    StringBuilder str = new StringBuilder();
                    int ind = messageBytes.Length;
                    Array.Resize(ref messageBytes, messageBytes.Length + qSize * 2);
                    foreach (byte i in bytesR)
                    {
                        messageBytes[ind++] = i;
                        //str.Append(i + " ");
                    }
                    foreach (byte i in bytesS)
                    {
                        messageBytes[ind++] = i;
                        //str.Append(i + " ");
                    }
                    if (filePath != null)
                    {
                        string path = filePath.Substring(0, filePath.LastIndexOf("\\"));
                        string newFileName = filePath.Substring(filePath.LastIndexOf("\\")+1);
                        newFileName = newFileName.Insert(newFileName.IndexOf("."), "DS");
                        string newFilePath = Path.Combine(path,newFileName); 
                        MessageBox.Show($"Digital signature has been created to path: {newFilePath}", "Information",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                        File.WriteAllBytes(newFilePath, messageBytes);
                    }

                    tbHash.Text = hash.ToString();
                    tbRS.Text = $"({r}, {s})";                    
                }
            }
        }

        public bool VerifySignature()
        {
            g = PowMod(h, (p - 1) / q, p);
            y = PowMod(g, x, p);
            bool isVerify = false;
            if(DsaValidation())
            {
                int hash = CountHash(messageBytes, 2 * qSize);
                int length = messageBytes.Length;
                int s = 0;
                for(int i=length - qSize; i < length ; i++)
                {
                    s <<= 8;
                    s += messageBytes[i];
                }
                int r = 0;
                for(int i = length - 2* qSize; i < length - qSize; i++)
                {
                    r <<= 8;
                    r += messageBytes[i];
                }

                int w = PowMod(s, q - 2, q); // (1 / s) % q;
                int u1 = (hash * w) % q;
                int u2 = (r * w) % q;
                int a = PowMod(g, u1, p);
                int b = PowMod(y, u2, p);
                v = ((a*b) % p) % q;

                if (v == r)
                    isVerify = true;

                tbV.Text = $"{v}, {u1}, {u2}";
                tbHash.Text = hash.ToString();
                tbRS.Text = $"({r}, {s})";


                if (v == r)
                {
                    MessageBox.Show("Digital signature is correct", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    isVerify = true;
                }
                else
                    MessageBox.Show("Incorrect signature, check your Menu input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return isVerify;
        }

        private int CountHash(byte[] message, int offset = 0)
        {
            int result = 0;
            int h = h0;
            int n = q;
            for(int i = 0; i < message.Length - offset; i++)
            {
               if(message[i] != 0)
                 h = PowMod(h + message[i], 2, n);
            }
            result = h;
            return result;
        }
        private void btnCreateSignature_Click(object sender, RoutedEventArgs e)
        {
            if (cbMain.IsChecked == false)
                CreateSignature();
            else
                VerifySignature();
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                filePath = fileDialog.FileName;
                messageBytes = File.ReadAllBytes(filePath);
                foreach (byte b in messageBytes)
                    tbHash.Text += b.ToString()+ " ";
            }
        }


        private void cbMain_Checked(object sender, RoutedEventArgs e)
        {
            btnCreateDS.Content = "Verify";
        }

        private void cbMain_Unchecked(object sender, RoutedEventArgs e)
        {
            btnCreateDS.Content = "Create Signature";
        }

        private void tbP_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbP.Text, out p);
        }
        private void tbQ_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbQ.Text, out q);

            if (q < byte.MaxValue)
                qSize = 1;
            else if (q < Int16.MaxValue)
                qSize = 2;
            else if (q < Int32.MaxValue)
                qSize = 4;
            else
                qSize = 8;
        }

        private void tbX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbX.Text, out x);

        }

        private void tbK_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbK.Text, out k);
        }

        private void tbH_TextChanged(object sender, TextChangedEventArgs e)
        {
            Int32.TryParse(tbH.Text, out h);
        }
    }
}
