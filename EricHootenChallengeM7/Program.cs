using System;

namespace EricHootenChallengeM7
{

    class Customer
    {
        private String FirstName, LastName, Email;
        private int ID;
        
        public Customer() { }

        public Customer(string firstName, string lastName, string email, int iD)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ID = iD;
        }

        public String GetDisplayText()
        {
            return "Customer Name: " + FirstName + " " + LastName + "\n" + "Email: " + Email + "\n" + "ID: " + ID.ToString();
        }

        public int getID()
        {
            return ID;
        }
    }

    class CustomerList
    {
        public delegate void ChangeHandler(CustomerList customers);
        public event ChangeHandler? Changed;

        private List<Customer> customers;
        
        private int count;
        public CustomerList()
        {
            customers = new List<Customer>();
            count = 0;
            Changed = CustomerList_Changed;
            
        }

        public Customer this[int index]
        {
            get => customers[index];
            set => customers[index] = value;

        }

        private static void CustomerList_Changed(CustomerList customers)
        {
            Console.WriteLine("***************************\nEmployees\n");
            for (int i = 0; i < customers.count; i++)
            {
                
                Console.WriteLine(customers[i].GetDisplayText());
                Console.WriteLine("\n");
            }
            
        }
        public void Add(Customer customer) 
        {
            count = count + 1;
            
            customers.Add(customer);
            Changed(this);
            
            
            
        }

        public void Remove(Customer customer) 
        {
            Customer remCustomer = customers.Find(customertemp => customertemp.getID() == customer.getID());
            Console.WriteLine("\n remover\n" + remCustomer.GetDisplayText());
            count = count - 1;
            customers.Remove(remCustomer);
            Changed(this);
            
        }

      
    }

    class Program
    {
        static void Main()
        {
            //Testing values
            Customer uno = new Customer("Eric","Hooten","ebhgcp@umsystem.edu",816);
            Customer dos = new Customer("Brett", "Hooten", "bfhjty@umsystem.edu", 815);
            Customer tres = new Customer("Eli", "Schneider", "email@email.com", 922);

            CustomerList customerList= new CustomerList();

            customerList.Add(uno);
            customerList.Add(dos);
            customerList.Add(tres);

            Console.Clear();


            
            Console.WriteLine("Hello User! This program allows you to manipulate a list of customers by either:\n   (1) adding a new customer  \n   (2) deleting an existing customer");
            Console.WriteLine("\n\nTo add a customer, please type '1' \nTo remove a customer, please type '2'\nTo exit the program, please type '3'");

            String input = "";
            while (input != "3")
            {
             
                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("\nPlease input customer's first name: ");
                    String first = Console.ReadLine();
                    Console.WriteLine("\nPlease input customer's last name: ");
                    String last = Console.ReadLine();
                    Console.WriteLine("\nPlease input customer's email: ");
                    String email = Console.ReadLine();
                    Console.WriteLine("\nPlease input customer's ID number: ");
                    int id = int.Parse(Console.ReadLine());

                    Customer c = new Customer(first, last, email, id);
                    customerList.Add(c);
                    Console.WriteLine("\n!!!!!!Customer Added!!!!!!\n");
                }

                if (input == "2")
                {
                    Console.WriteLine("\nTo remove please input customer's unique ID number");
                    int id = int.Parse(Console.ReadLine());

                    Customer c = new Customer(null ,null ,null , id);
                    customerList.Remove(c);
                    Console.WriteLine("\n!!!!!!Customer Removed!!!!!!\n");

                }

                Console.WriteLine("\n\nTo add a customer, please type '1' \nTo remove a customer, please type '2'\nTo exit the program, please type '3'");
            }
        }
    }
}
