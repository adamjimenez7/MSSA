using System;
using System.Collections.Generic;

namespace Exercise_9A
{
    class UserList
    {
        Dictionary<string, string> UserDict = new Dictionary<string, string>();

        public void AddUser(Tuple<string, string> newUser)
        {
            if(!UserDict.ContainsKey(newUser.Item1)) //If username doesn't exist, add user/password combo
            {
                UserDict.Add(newUser.Item1, newUser.Item2);
                System.Console.WriteLine($"User {newUser.Item1} successfully created!");
            }
            
            else //If username does exist, send user back to main menu
            {
                System.Console.WriteLine("Username already exists. You are now being returned to the main menu.");
            }
        }

        public void AuthUser()
        {
            System.Console.WriteLine("Please enter a username: ");
            string userName = Console.ReadLine();

            System.Console.WriteLine("Please enter a password: ");
            string userPass = Console.ReadLine();
            PassEncrypt newEncryptPass = new PassEncrypt(); //Instantiate new hashing object

            if(!UserDict.ContainsKey(userName))
            {
                System.Console.WriteLine("Sorry, that username is not in the current list of users.");
            }

            else if(UserDict[userName] == newEncryptPass.EncryptPass(userPass)) //Check hashed password against username
            {
                System.Console.WriteLine("You have successfully authenticated.");
            }

            else
            {
                System.Console.WriteLine("Invalid entry. You are now being returned to the main menu.");
            }
        }

        public void ShowUsers()
        {
            foreach(KeyValuePair<string, string> user in UserDict)
            {
                System.Console.WriteLine($"Username: {user.Key} ; Password(hashed): {user.Value}");
            }
        }
    }
}