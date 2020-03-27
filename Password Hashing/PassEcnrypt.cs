using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Exercise_9A
{
    class PassEncrypt
    {
        public string EncryptPass(string inputPass)
        {
            MD5 hash = MD5.Create(); //new MD5 hash instance
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputPass); //Convert input password to byte array (input for MD5 ComputeHash method)
            byte[] hashArray = hash.ComputeHash(inputBytes); //Change inputPass into MD5-hash byte array
            string outputPass = ""; //new variable to store newly hashed password as string

            for (int i = 0; i < hashArray.Length; i++)
            {
                outputPass += hashArray[i].ToString(); //Iterating over hashed byte array and placing items in string-type hash password
            }
            return outputPass;
        }
    }
}