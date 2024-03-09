using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
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
            RusProbilities();

        }

        private void func1(object sender, RoutedEventArgs e)
        {
            tb2.Text = "";
            if (func4())
            {
                func3(Convert.ToInt32(tb3.Text), 1);
                Symbol_probabilities(tb1.Text);
                func5();
                
            }
                    
        }

        public Dictionary<char, double> letterProbability = new();
        public Dictionary<char, double>    RusProbability = new();





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
                int t = Convert.ToInt32(tb1.Text[i]);
                if (!(tb1.Text[i] <= 57 && tb1.Text[i] >= 48 || tb1.Text[i] == 32))
                {
                    t = Convert.ToInt32(tb1.Text[i]) + shift * znak;
                    if (t > 1103)
                        while (t > 1103)
                            t -= 32;
                    if (t < 1072)
                        while (t < 1072)
                            t += 32;
                }
            
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
                        if (!((tb1.Text[i] <= 1103 && tb1.Text[i] >= 1072) || (tb1.Text[i] <= 57 && tb1.Text[i]>= 48) || tb1.Text[i] == 32) )
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
            StreamReader f = new StreamReader(arg0);
            string[] s = f.ReadLine().Split('|');
            f.Close();
            tb1.Text = s[0];
            tb3.Text = s[1];

        }
        public string AllLeters = "абвгдежзийклмнопрстуфхцшщъыьэюя";
        public void RusProbilities()
        {
          
            RusProbability.Add('а', 8.04);
            RusProbability.Add('б', 1.55);
            RusProbability.Add('в', 4.75);
            RusProbability.Add('г', 1.88);
            RusProbability.Add('д', 2.95);
            RusProbability.Add('е', 8.21);
            RusProbability.Add('ж', 0.88);
            RusProbability.Add('з', 1.61);
            RusProbability.Add('и', 7.98);
            RusProbability.Add('й', 1.36);
            RusProbability.Add('к', 3.49);
            RusProbability.Add('л', 4.32);
            RusProbability.Add('м', 3.11);
            RusProbability.Add('н', 6.72);
            RusProbability.Add('о', 10.61);
            RusProbability.Add('п', 2.82);
            RusProbability.Add('р', 5.38);
            RusProbability.Add('с', 5.71);
            RusProbability.Add('т', 5.83);
            RusProbability.Add('у', 2.28);
            RusProbability.Add('ф', 0.41);
            RusProbability.Add('х', 1.02);
            RusProbability.Add('ц', 0.58);
            RusProbability.Add('ч', 1.23);
            RusProbability.Add('ш', 0.55);
            RusProbability.Add('щ', 0.34);
            RusProbability.Add('ъ', 0.03);
            RusProbability.Add('ы', 1.91);
            RusProbability.Add('ь', 1.39);
            RusProbability.Add('э', 0.31);
            RusProbability.Add('ю', 0.63);
            RusProbability.Add('я', 2.00);


        }
        private void func5()
        {
            if (tb1.Text.Length > 10)
                tb4.Text = tb1.Text.Substring(0, 10);
            else
                tb4.Text = tb1.Text;

            double x = 0;
            for (int i = 0; i < 31; i++)
            {
                
                Char t = AllLeters[i];
                if (tb1.Text.IndexOf(t) != -1)
                    x += (letterProbability[t] - RusProbability[t]) * (letterProbability[t] - RusProbability[t]) / RusProbability[t];
            }
            tb4.Text += " | ";
            tb4.Text += Math.Round(x,2).ToString();
        }
        private void Symbol_probabilities(string inputText)
        {
            string s = inputText;
            for (int i = 0; i < s.Length; i++)
                if (AllLeters.IndexOf(s[i]) == -1)
                {
                    s = s.Remove(i, 1);
                    i--;
                }
            letterProbability = new();
            int totalCharacters = s.Length;

            foreach (char character in s)
            {
                if (letterProbability.ContainsKey(character)) { letterProbability[character] += 1.0 / totalCharacters; }
                else { letterProbability[character] = 1.0 / totalCharacters; }
            }

            letterProbability = letterProbability.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
