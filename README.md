# BankAccount
Personal Project: a small application that simulates a bank account
<br>This application contains two classses:
- the first class allows you to create a bank account and that allows you to log into an account: this class is static so you don't have to create an object to when you want to create an account/login;
- the second class lets you modify the content of the account selected in the first class.

<br><br>To create an account, the program creates a text file with the ID's name that contains all the account's data. The text files can be found inside the 'Accounts' folder, in the 'bin' folder (I also uploaded some files here so you can see how one looks like. One problem is that the passwords are not encrypted, but it can be solved sometime). <br>Both classes use 'try catch' instructions to check if the files exist or if they can be read.
<br><br>After succesfully loging in, the first class automatically creates an object of the second class type that receives as a parameter the account's ID to use the data from the file that has the ID's name. This class is not static.
<br><br>Both classes let you decide what method to use by getting your input and placing it into a 'switch' structure. These structures are included into an infinite loop ("while(true)") so you can perform multiple actions without closing the program each time. The program can be stopped using an instruction from the respective 'switch' structures.
