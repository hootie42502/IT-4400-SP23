using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Printing;
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

namespace EricHootenChallengeM4
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


        private void SelectButtonClicked(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime appt = new DateTime();
            try
            {
                appt = DateTime.ParseExact((dateDisplay.Text + " " + timeDisplay.Text), "MM/dd/yyyy HH:mm tt", CultureInfo.InvariantCulture);
            } 
            catch (System.FormatException ex) 
            {
                appt = DateTime.ParseExact((dateDisplay.Text + " " + timeDisplay.Text), "M/d/yyyy HH:mm tt", CultureInfo.InvariantCulture);
            }
            
            System.TimeSpan diff = appt - now;
            outputBox.Text =" Your appointment is on " + appt.ToString("dddd, MMMM dd, yyyy")+  " at " + appt.ToString("HH:mmtt") + " which is " + diff.ToString("%d") + " days away!";
        }

        private void UpButtonClicked(object sender, EventArgs e)
        {
            int cursorPosition = timeDisplay.CaretIndex;
            timeDisplay.Text = GenerateNewUpTimeString(timeDisplay.Text, timeDisplay.CaretIndex);
            timeDisplay.SelectionStart = cursorPosition;
        }

        private String GenerateNewUpTimeString(String s, int n)
        {
            String str1, str2,change;

            if (n == 0 && s[n] == '0')
            {
                str1 = s.Substring(0, n);
                change = "10";
                str2 = s.Substring(n + 2);
                return str1 + change + str2;
            }
            if (n==0 && s[n] == '1')
            {
                str1 = s.Substring(0, n);
                change = "0";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }
            if (n == 1 && s[n] == '2' && s[n-1] == '1')
            {
                str1 = s.Substring(0, n);
                change = "0";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }

            if (s[n] == '9')
            {
                str1 = s.Substring(0, n);
                change = "0";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }

            if(n==3 && s[n] == '5')
            {
                str1 = s.Substring(0, n);
                change = "0";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }



            if (s[n] == ':' || s[n] == ' ' || s[n] == 'M')
            {
                return s;
            }
            if (s[n] == 'A')
            {
                 str1 = s.Substring(0, n);
                 change = "P" ;
                 str2 = s.Substring(n + 1);

                return str1 + change + str2;
            }
            if (s[n] == 'P')
            {
                 str1 = s.Substring(0, n);
                 change = "A";
                 str2 = s.Substring(n + 1);

                return str1 + change + str2;
            }

            str1 = s.Substring(0, n);
            change = (int.Parse(s[n].ToString()) + 1).ToString(); ;
            str2 = s.Substring(n + 1);

            return str1 + change + str2;


        }

        private void DownButtonClicked(object sender, EventArgs e)
        {
            int cursorPosition = timeDisplay.CaretIndex;
            timeDisplay.Text = GenerateNewDownTimeString(timeDisplay.Text, timeDisplay.CaretIndex);
            timeDisplay.SelectionStart = cursorPosition;
        }

        private String GenerateNewDownTimeString(String s, int n)
        {
            String str1, str2, change;
            if (n == 1 && s[n] == '0' && s[n-1] == '0')
            {
                change = "12";
                str2 = s.Substring(n + 1);
                return change + str2;
            }
            if (n == 0 && s[n] == '0')
            {
                str1 = s.Substring(0, n);
                change = "1";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }
            if (n == 1 && s[n] == '0' && s[n - 1] == '1')
            {
                str1 = s.Substring(0, n);
                change = "2";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }
            if (n == 3 && s[n] == '0')
            {
                str1 = s.Substring(0, n);
                change = "5";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }
            if (s[n] == '0')
            {
                str1 = s.Substring(0, n);
                change = "9";
                str2 = s.Substring(n + 1);
                return str1 + change + str2;
            }

            



            if (s[n] == ':' || s[n] == ' ' || s[n] == 'M')
            {
                return s;
            }
            if (s[n] == 'A')
            {
                str1 = s.Substring(0, n);
                change = "P";
                str2 = s.Substring(n + 1);

                return str1 + change + str2;
            }
            if (s[n] == 'P')
            {
                str1 = s.Substring(0, n);
                change = "A";
                str2 = s.Substring(n + 1);

                return str1 + change + str2;
            }

            str1 = s.Substring(0, n);
            change = (int.Parse(s[n].ToString()) - 1).ToString(); ;
            str2 = s.Substring(n + 1);

            return str1 + change + str2;


        }
    }
}
