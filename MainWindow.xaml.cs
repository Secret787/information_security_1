using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace information_security_1
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

        private void func1(object sender, RoutedEventArgs e)
        {
            tb2.Text = "";
            if (func4())
                func3(Convert.ToInt32(tb3.Text), 1);
        }

        private void func2(object sender, RoutedEventArgs e)
        {
            tb2.Text = "";
            if (func4())
                func3(Convert.ToInt32(tb3.Text), -1);
        }
        private void func3(int shift, int znak)
        {
            if (shift >= 32)
                shift -= 32;
            for (int i = 0; i < tb1.Text.Length; i++)
            {
                int t = Convert.ToInt32(tb1.Text[i]) + shift * znak;
                if (t > 1103)
                    while (t > 1103)
                        t -= 32;
                if (t < 1072)
                    while (t < 1072)
                        t += 32;
                tb2.Text += Convert.ToChar(t);

            }
        }
        private bool func4 () 
        {
            bool err = false;
            int shift = 0;
            if (tb1.Text != string.Empty && tb3.Text != string.Empty)
            {
                if (int.TryParse(tb3.Text, out shift))
                {
                    for (int i = 0; i < tb1.Text.Length; i++)
                    {
                        if (!(tb1.Text[i] <= 1103 && tb1.Text[i] >= 1072))
                        {
                            err = false;
                            break;
                        }
                        if (i == tb1.Text.Length - 1)
                            err = true;
                    }
                }
            }

            return err;

        }
        public static string arg0 = @"..\123.txt";

        private void Save(object sender, RoutedEventArgs e)
        {
            if (func4())
            {
                StreamWriter f = new StreamWriter(arg0, false);
                f.WriteLine(tb1.Text + "|" + tb3.Text);
                f.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            StreamReader f = new StreamReader(arg0);
            string[] s = f.ReadLine().Split('|');
            f.Close();
            tb1.Text = s[0];
            tb3.Text = s[1];

        }
    }
}
