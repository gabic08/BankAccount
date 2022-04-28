using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Bank_Account
{
    static class BankAccount
    {
        private static bool createAccount()
        {
            bool fileExist;
            string name;
            string pin;
            int ID;
            int balance = 0;

            
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            
            Console.Write("Enter your pin: ");
            pin = Console.ReadLine();
            if(pin.Length != 4 ||!(Convert.ToInt32(pin) is int))
            {
                Console.WriteLine("THE PIN MUST CONTAIN ONLY 4 NUMBERS!");
                return false;
            }
            

            Console.Write("Enter an ID: ");
            try
            {
                ID = Convert.ToInt32(Console.ReadLine());
            }
            
            catch(FormatException)
            {
                Console.WriteLine("ID MUST BE A NUMBER!");
                return false;
            }

            fileExist = File.Exists(("Accounts/" + ID + ".txt"));
            if (fileExist)
            {
                Console.WriteLine("THIS ID IS ALREADY USED!");
                return false;
            }

            else
            {
                using (StreamWriter sw = File.CreateText("Accounts/" + ID + ".txt"))
                {
                    sw.WriteLine(ID);
                    sw.WriteLine(name);
                    sw.WriteLine(pin);
                    sw.WriteLine(balance);
                }
            }

            return true;

        }
        private static bool login()
        {
            bool fileExist;
            string pin;
            int ID;

            Console.Write("Enter your ID: ");
            try
            {
                ID = Convert.ToInt32(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("ID MUST BE A NUMBER!");
                return false;
            }


            Console.Write("Enter your pin: ");
            pin = Console.ReadLine();
            if (pin.Length != 4 || !(Convert.ToInt32(pin) is int))
            {
                Console.WriteLine("THE PIN MUST CONTAIN ONLY 4 NUMBERS!");
                return false;
            }
            
            fileExist = File.Exists(("Accounts/" + ID + ".txt"));
            if (!fileExist)
            {
                Console.WriteLine("THE ACCOUNT DOES NOT EXIST!");
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");
                if(lines.Length == 4 && Convert.ToInt32(lines[0]) is int && Convert.ToInt32(lines[0]) == ID && (lines[2].Length == 4 || (Convert.ToInt32(lines[2]) is int)) && Convert.ToInt32(lines[3]) is int){

                    if (pin == lines[2])
                    {
                        Console.WriteLine("Login succesful!");
                        AccountManagement ac = new AccountManagement(ID);
                        ac.start();
                    }
                    else
                    {
                        Console.WriteLine("WRONG PASSWORD!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: THIS FILE CONTAINS SOMETHING WRONG");
                    return false;
                }
                    

            }

            return true;
            
           

        }
        public static void start()
        {
            while (true)
            {
                Console.WriteLine("\n-----Welcome!-----\n");
                Console.WriteLine("1)Create account");
                Console.WriteLine("2)Login");
                Console.WriteLine("3)Exit");
                int c;
                string p;
                Console.Write("\nSelect your action: ");

                p = Console.ReadLine();
                if (!(p == "1" || p == "2" || p == "3"))
                {
                    Console.WriteLine("SELECT A VALID NUMBER");
                }
                

                else
                {
                    c = Convert.ToInt32(p);
                    switch (c)
                    {
                        case 1:
                            BankAccount.createAccount();
                            break;

                        case 2:
                            BankAccount.login();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }
                        
                }
                    
                
            }
        }
        
    }
}
