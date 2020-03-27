using System;
using System.Collections.Generic;

namespace Exercise_9A
{
    class NewUser
    {
        public static Tuple<string, string> CreateNewUser()
        {
            System.Console.WriteLine("Please enter a username: ");
            string newUserName = Console.ReadLine();

            System.Console.WriteLine("Please enter a password: ");
            string newUserPass = Console.ReadLine();
            PassEncrypt newEncryptPass = new PassEncrypt(); //Instantiate new hashing object

            Tuple<string, string> newUser = new Tuple<string, string>(newUserName, newEncryptPass.EncryptPass(newUserPass)); //Input username and hashed password into UserList dictionary

            return newUser;
        }
    }
}