using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Final.classes
{
    public class Client
    {
        public String userName { get; set; }
        public String password { get; set; }
        public List<Account> Accounts { get; set; }

        public Client(String userName, String password, List<Account> accounts)
        {
            this.userName = userName;
            this.password = password;
            this.Accounts = accounts;
        }

        public Client(String userName, String password)
        {
            this.userName = userName;
            this.password = password;
        } 

        public bool login(String userName, String password)
        {
            if(userName == null || password == null) { return false; }
            if(userName.Equals(this.userName) && password.Equals(this.password)) { return true; }
            return false;
        }

        public void logout()
        {

        }

        




    }


}
