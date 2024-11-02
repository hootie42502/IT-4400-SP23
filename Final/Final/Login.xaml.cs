using Final.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Login : Page
    {
        List<Client> clients = new List<Client>();
        List<Account> accounts = new List<Account>();
        public Login()
        {
            InitializeComponent();

            CompoundInterestAccount acctr = new CompoundInterestAccount(12);
            
            acctr.AccountName = "Eric Checking";
            SimpleInterestAccount acct = new SimpleInterestAccount(13);
            acct.AccountName = "Eric Savings";
            accounts.Add(acctr);
            accounts.Add(acct);
            Client test = new Client("Eric", "1234", accounts);

            clients.Add(test);

            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool loginSuccess = false;
            try
            {
                for(int i = 0; i < clients.Count; i++)
                {
                    if (FirstNameTextBox.Text.Equals(clients[i].userName) && LastNameTextBox.Text.Equals(clients[i].password))
                    {
                        this.NavigationService.RemoveBackEntry();
                        this.NavigationService.Navigate(new Bank(clients[0]));
                        loginSuccess= true;
                    }
                }
                if(!loginSuccess) { MessageBox.Show($"Invalid Username or Password"); }
                
            } catch
            {
                
            }
            
        }
    }
}
