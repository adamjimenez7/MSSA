using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Exercise_4A
{
    class Session
    {
        public void BeginSession()
        {
            //Determine what user wants to do...            
            Console.WriteLine("Welcome to the Atomic Cipher Program!");
            Console.WriteLine(@"Would you like to...
            1) Encrypt
            2) Decrypt
            3) Exit
            (Please enter only the number)");
            char userChoice = Console.ReadKey().KeyChar;
            System.Console.WriteLine("\n");

            try
            {
                if (userChoice == '1' || userChoice == '2')
                {
                    SessionInit(userChoice); //With valid entry, send to session initializer method with "cookie"
                }
                else if (userChoice == '3')
                {
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                }
                else
                {
                    throw new IndexOutOfRangeException("Invalid entry. Exiting");
                }
            }

            finally
            {
                BeginSession();
            }
        }

        //Method that will format strings appropriately before calling encryption/decryption methods
        public void SessionInit(char userChoice)
        {
            string temp;
            if (userChoice == '1')
            {
                temp = "encrypt";
            }
            else
            {
                temp = "decrypt";
            }

            //Getting user input for string to encrypt/decrypt
            Console.WriteLine($"What is the message you would like {temp}ed? (Please enter only letters)");
            string userString = Console.ReadLine().ToUpper(); //Converting to upper first to limit range in for loop
            string stringToXcrypt = ""; //Empty variable to store all eligible characters
            int count = 0; //Counter to keep track of new string index
            for (int i = 0; i < userString.Length; i++)
            {
                if (userString[i] >= 65 && userString[i] <= 90) //If character in string is a capital letter, put in empty string. Else, ignore it
                {
                    stringToXcrypt += userString[i];
                    count++;
                }
            }

            if (userString != stringToXcrypt) //Courtesy to show what string has been changed to, if it has been changed
            {
                Console.WriteLine($"You entered invalid characters. The string to {temp} is: {stringToXcrypt}");
            }

            //Performing the same operations as above for the key
            Console.WriteLine($"What is the string key you would like to use to {temp} your message? (Please enter only letters)");
            string userCode = Console.ReadLine().ToUpper();
            string xcryptionCode = "";
            count = 0; //Starting counter over
            for (int i = 0; i < userCode.Length; i++)
            {
                if (userCode[i] >= 65 && userCode[i] <= 90) //
                {
                    xcryptionCode += userCode[i];
                    count++;
                }
            }

            if (userCode != xcryptionCode) //Courtesy to show what string has been changed to, if it has been changed
            {
                Console.WriteLine($"You entered invalid characters. The string that will be used as an {temp}ion code is: {xcryptionCode}");
            }

            Console.WriteLine($"String to {temp}: {stringToXcrypt}        {temp}ion code: {xcryptionCode}");

            if (userChoice == '1')
            {
                EncryptCode newEncrypt = new EncryptCode();
                SessionOutput(newEncrypt.EncryptMessage(stringToXcrypt, xcryptionCode));
            }
            else if (userChoice == '2')
            {
                DecryptCode newDecrypt = new DecryptCode();
                SessionOutput(newDecrypt.DecryptMessage(stringToXcrypt, xcryptionCode));
            }
        }
        
        public void SessionOutput(string xcryptedString)
        {
            string outputString = "";
            for (int i = 0; i < xcryptedString.Length; i++)
            {
                outputString += xcryptedString[i];
            }

            Console.WriteLine($"Output string: {outputString}\n");
        }
    }
}
