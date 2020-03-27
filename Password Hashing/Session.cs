using System;
using System.Collections.Generic;

namespace Exercise_9A
{
    class Session
    {
        UserList NewUserList = new UserList();

        public void StartSession()
        {
            Console.WriteLine(@"Please select an option: 
            1. Create account
            2. Authenticate a user
            3. Exit the application (all stored username/password combinations will be displayed)");
            char userSelect = Console.ReadKey().KeyChar;
            System.Console.WriteLine("\n");
            
            try
            {
                if(userSelect == '1')
                {
                    NewUserList.AddUser(NewUser.CreateNewUser());
                }
                else if(userSelect == '2')
                {
                    NewUserList.AuthUser();
                }
                else if(userSelect == '3')
                {
                    NewUserList.ShowUsers();
                    Environment.Exit(0);
                }
                
                else if (userSelect != '1' || userSelect != '2' | userSelect != '3')
                {
                    throw new IndexOutOfRangeException("Invalid entry. Exiting");
                }
            }

            finally
            {
                StartSession();
                //System.Console.WriteLine("Exiting the program...");
            }
        }
    }
}