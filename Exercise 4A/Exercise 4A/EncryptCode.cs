using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercise_4A
{
    class EncryptCode
    {       
        public string EncryptMessage(string stringToEncrypt, string encryptionCode)
        {
            string encryptedString = ""; //Empty variable to hold the new string since strings are immutable
            int encryptionAdd; //Variable to determine ASCII value after decryption operations
            int count = 0; //temp variable to keep track of place in encryption key

            //**********Use when you want to repeat encryption code, e.g. EC = "CAT", will encrypt using CATCATCATCAT**********
            /*
            for (int i = 0; i < stringToEncrypt.Length; i++)
            {
                int cypherLoop = count % encryptionCode.Length; //Variable to determine index of encryption code when encryption will use same code repeatedly
                encryptionAdd = (stringToEncrypt[i] + (encryptionCode[cypherLoop] - 64)) < 91 ? stringToEncrypt[i] + (encryptionCode[cypherLoop] - 64) : (stringToEncrypt[i] + (encryptionCode[cypherLoop] - 64)) % 91 + 65; //Ensure encrypted letters still have ASCII values of capital letters
                char character = (char) encryptionAdd;
                encryptedString += (character.ToString()); 
                count++;
            }
            */

            //**********Use when you want to use entire encryption key, then the message itself to encrypt, e.g. EC = "CAT", will encrypt using CATABCD....N where ABCD...N = first N letters of string to encrypt**********
            for (int i = 0; i < stringToEncrypt.Length; i++)
            {
                if (count < encryptionCode.Length) //If count is shorter than encryption code length (we have not used every letter in encryption string)
                {
                    encryptionAdd = (stringToEncrypt[i] + (encryptionCode[count] - 64)) < 91 ? stringToEncrypt[i] + (encryptionCode[count] - 64) : (stringToEncrypt[i] + (encryptionCode[count] - 64)) % 91 + 65;
                    char character = (char)encryptionAdd;
                    encryptedString += (character.ToString());
                    count++;
                }
                else //After we exhaust encryption string, start at the first letter of the string to encrypt
                {
                    encryptionAdd = (stringToEncrypt[i] + (stringToEncrypt[count - encryptionCode.Length] - 64)) < 91 ? stringToEncrypt[i] + (stringToEncrypt[count - encryptionCode.Length] - 64) : (stringToEncrypt[i] + (stringToEncrypt[count - encryptionCode.Length] - 64)) % 91 + 65;
                    char character = (char)encryptionAdd;
                    encryptedString += (character.ToString());
                    count++;
                }
            }

            return encryptedString;
        }
    }
}
