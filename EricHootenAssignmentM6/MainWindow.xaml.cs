using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

namespace EricHootenAssignmentM6
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            input.Text += b.Content.ToString();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Calculate(sender,e);
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            input.Text= string.Empty;
        }
        private void Calculate(object sender, RoutedEventArgs e)
        {
            String op;
            int opIndex = 0;
            double op1, op2;
            try
            {
                if (input.Text.Contains("+"))
                {
                    opIndex = input.Text.IndexOf("+");
                }
                else if (input.Text.Contains("*"))
                {
                    opIndex = input.Text.IndexOf("*");
                }
                else if (input.Text.Contains("/"))
                {
                    opIndex = input.Text.IndexOf("/");
                }
                else if (input.Text.Contains("-"))
                {
                    if (input.Text[0] == '-')
                    {
                        String tempString = input.Text.Substring(1);
                        opIndex = tempString.IndexOf("-") + 1;
                    } else
                    {
                        opIndex = input.Text.IndexOf("-");
                    }
                }
                else
                {
                    throw new InvalidOperationException("No operator selected");
                }
            }
            catch (FormatException fEx)
            {
                input.Text = fEx.Message;
                return;
            }
            catch (OverflowException oEx)
            {
                input.Text = oEx.Message;
                return;
            }

            catch (Exception ex)
            {
                input.Text = ex.Message;
                return;
            }
            try
            {
                op = input.Text.Substring(opIndex, 1);

                op1 = Convert.ToDouble(input.Text.Substring(0, opIndex));

                op2 = Convert.ToDouble(input.Text.Substring(opIndex + 1, input.Text.Length - opIndex - 1));

                if (op == "+")
                {
                    input.Text = (op1 + op2).ToString();
                }
                else if (op == "-")
                {
                    input.Text = (op1 - op2).ToString();
                }
                else if (op == "*")
                {
                    input.Text = (op1 * op2).ToString();
                }
                else
                {
                    input.Text = (op1 / op2).ToString();
                }
            } catch
            {
                input.Text = "invalid input";
                return;
            }
            

           
        }
    }
    
}

