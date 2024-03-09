using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

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
        public static string arg0 = @"..\Data.txt";

        private void Save(object sender, RoutedEventArgs e)
        {
            string filename = "";
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dialog.FileName;
            }
            if (filename != "")
            {
                StreamWriter f = new StreamWriter(filename, false);
                f.WriteLine(tb1.Text + "|" + tb3.Text);
                f.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            string filename = "";
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Data"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dialog.FileName;
            }
            if (filename != "")
            {
                StreamReader f = new StreamReader(filename);
                string first_line = f.ReadLine();
                f.Close();
                string pattern = @"[^|][|]\d+";
                if (Regex.IsMatch(first_line, pattern, RegexOptions.IgnoreCase))
                {
                    string[] s = first_line.Split('|');
                    tb1.Text = s[0];
                    tb3.Text = s[1];
                }
            }
        }
    }
}
