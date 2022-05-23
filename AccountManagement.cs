using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Bank_Account
{
    class AccountManagement
    {
        private int ID;

        public AccountManagement(int ID)
        {
            this.ID = ID;
        }
        private void displayBalance()
        {
            string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");
            Console.WriteLine("\n-----Your balance is: " + lines[3]);

        }
        private bool depositMoney()
        {
            int sum;
            Console.Write("Enter the sum you want to deposit: ");
            try
            {
                sum = Convert.ToInt32(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("THE SUM MUST BE NUMERIC!");
                return false;
            }

            string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");

            int balance = Convert.ToInt32(lines[3]);
            balance = balance + sum;
            using (StreamWriter sw = new StreamWriter("Accounts/" + ID + ".txt"))
            {
                sw.WriteLine(lines[0]);
                sw.WriteLine(lines[1]);
                sw.WriteLine(lines[2]);
                sw.WriteLine(balance);
            }
            return true;
        }

        private bool withdrawMoney()
        {
            int sum;
            Console.Write("Enter the sum you want to withdraw: ");
            try
            {
                sum = Convert.ToInt32(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("THE SUM MUST BE NUMERIC!");
                return false;
            }

            string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");
            int balance = Convert.ToInt32(lines[3]);
            balance = balance - sum;
            if (balance < 0)
            {
                Console.WriteLine("INSUFFICIENT FUNDS!");
                return false;
            }

            else
            {
                using (StreamWriter sw = new StreamWriter("Accounts/" + ID + ".txt"))
                {
                    sw.WriteLine(lines[0]);
                    sw.WriteLine(lines[1]);
                    sw.WriteLine(lines[2]);
                    sw.WriteLine(balance);
                }

            }
            return true;
        }

        private bool transferMoney()
        {
            int sum, IdTransfer;
            Console.Write("Enter the sum you want to transfer: ");
            try
            {
                sum = Convert.ToInt32(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("THE SUM MUST BE NUMERIC!");
                return false;
            }


            Console.Write("Enter the ID you want to transfer money to: ");
            try
            {
                IdTransfer = Convert.ToInt32(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("ID MUST BE A NUMBER!");
                return false;
            }

            bool fileExist = File.Exists(("Accounts/" + IdTransfer + ".txt"));
            if (!fileExist)
            {
                Console.WriteLine("THE ACCOUNT DOES NOT EXIST!");
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");
                int balance = Convert.ToInt32(lines[3]);
                balance = balance - sum;
                if (balance < 0)
                {
                    Console.WriteLine("INSUFFICIENT FUNDS!");
                    return false;
                }

                else
                {
                    using (StreamWriter sw = new StreamWriter("Accounts/" + ID + ".txt"))
                    {
                        sw.WriteLine(lines[0]);
                        sw.WriteLine(lines[1]);
                        sw.WriteLine(lines[2]);
                        sw.WriteLine(balance);
                    }

                    string[] linesT = File.ReadAllLines("Accounts/" + IdTransfer + ".txt");
                    int balanceT = Convert.ToInt32(linesT[3]);
                    balanceT = balanceT + sum;

                    using (StreamWriter sw = new StreamWriter("Accounts/" + IdTransfer + ".txt"))
                    {
                        sw.WriteLine(linesT[0]);
                        sw.WriteLine(linesT[1]);
                        sw.WriteLine(linesT[2]);
                        sw.WriteLine(balanceT);
                    }
                }


            }
            return true;
        }

        private bool changePassword()
        {
            Console.Write("Enter your new pin: ");
            string pin;
            pin = Console.ReadLine();
            if (pin.Length != 4 || !(Convert.ToInt32(pin) is int))
            {
                Console.WriteLine("THE PIN MUST CONTAIN ONLY 4 NUMBERS!");
                return false;
            }
            else
            {
                string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");
                using (StreamWriter sw = new StreamWriter("Accounts/" + ID + ".txt"))
                {
                    sw.WriteLine(lines[0]);
                    sw.WriteLine(lines[1]);
                    sw.WriteLine(pin);
                    sw.WriteLine(lines[3]);
                }
            }
            return true;
        }

        private bool deleteAccount()
        {
            Console.Write("\n\tARE YOU SURE YOU WANT TO DELETE YOUR ACCOUNT?  Y/N:   ");
            string c;
            c = Console.ReadLine();
            if (c.ToUpper() == "Y")
            {
                Console.WriteLine("ACCOUNT DELETED!");
                File.Delete("Accounts/" + ID + ".txt");
                return true;
            }

            else if (c.ToUpper() == "N")
                return false;

            else
            {
                Console.WriteLine("YOU HAVE TO ENTER Y OR N");
                return false;
            }

        }

       public bool start()
        {
            while (true)
            {
                if (File.Exists(("Accounts/" + ID + ".txt"))){
                    string[] lines = File.ReadAllLines("Accounts/" + ID + ".txt");

                    Console.WriteLine("\n\n-----Welcome, " + lines[1] + "! -----\n");
                    Console.WriteLine("1)Display your balance");
                    Console.WriteLine("2)Deposit money");
                    Console.WriteLine("3)Withdraw money");
                    Console.WriteLine("4)Transfer money");
                    Console.WriteLine("5)Change your password");
                    Console.WriteLine("6)Delete your account");
                    Console.WriteLine("7)Back");
                    Console.WriteLine("8)Exit");
                    int c;
                    string p;
                    Console.Write("\nSelect your action: ");

                    p = Console.ReadLine();
                    if (!(p == "1" || p == "2" || p == "3" || p == "4" || p == "5" || p == "6" || p == "7" || p == "8"))
                    {
                        Console.WriteLine("SELECT A VALID NUMBER");
                    }


                    else
                    {
                        c = Convert.ToInt32(p);
                        switch (c)
                        {
                            case 1:
                                this.displayBalance();
                                break;
                            case 2:
                                this.depositMoney();
                                break;
                            case 3:
                                this.withdrawMoney();
                                break;
                            case 4:
                                this.transferMoney();
                                break;
                            case 5:
                                this.changePassword();
                                break;
                            case 6:
                                this.deleteAccount();
                                break;
                            case 7:
                                return false;
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;

                        }
                    }

                }
                else
                {
                    return false;
                }
                

            }
        }
    }
}
