using Final.classes;
using System;
using System.Collections.Generic;
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

namespace Final
{
    /// <summary>
    /// Interaction logic for Bank.xaml
    /// </summary>
    public partial class Bank : Page
    {
        List<Account> accounts = new List<Account>();
        Account currAccount;
        Client client;

        public Bank(Client client)
        {
            this.client = client;
            accounts.AddRange(client.Accounts);
            if(client.Accounts.Count > 0)
            {
                currAccount = accounts[0];

            }
            
            InitializeComponent();

            DataContext = new { accounts, currAccount };
        }

        private void accounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currAccount = AccountsListBox.SelectedItem as Account;
            this.DataContext = new { accounts, currAccount };
        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (currAccount.Equals(accounts[i]))
                {
                    accounts[i].Withdraw(Convert.ToDouble(TransferAmount.Text));
                }
            }
        }

        private void Deposit_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (currAccount.Equals(accounts[i]))
                {
                    accounts[i].Deposit(Convert.ToDouble(TransferAmount.Text));
                }
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (accountType.Text.Equals("Simple Interest"))
            {
                SimpleInterestAccount acct = new SimpleInterestAccount(Convert.ToDouble(NewBalance.Text));
                acct.AccountName = NewAccountName.Text;
                accounts.Add(acct);

            } else if (accountType.Text.Equals("Compound Interest"))
            {
                CompoundInterestAccount acct = new CompoundInterestAccount(Convert.ToDouble(NewBalance.Text));
                acct.AccountName = NewAccountName.Text;
                accounts.Add(acct);
            }
            this.client.Accounts = accounts;
            currAccount = accounts.LastOrDefault();
            AccountsListBox.ItemsSource = accounts;
            this.DataContext = new { accounts, currAccount };

            this.NavigationService.RemoveBackEntry();
            this.NavigationService.Navigate(new Bank(this.client));
        }

        private void Year_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                accounts[i].UpdateAccountWithInterest();
                AccountsListBox.ItemsSource = accounts;
                this.DataContext = new { accounts, currAccount };
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.RemoveBackEntry();

            this.NavigationService.Navigate(new Login());
        }
    }
}
