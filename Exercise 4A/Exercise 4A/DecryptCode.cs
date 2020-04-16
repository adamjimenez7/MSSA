using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_4A
{
    class DecryptCode
    {
        public string DecryptMessage(string stringToDecrypt, string DecryptionCode)
        {
            string decryptedString = ""; //Empty variable to hold the new string since strings are immutable
            int decryptionSub; //Variable to determine ASCII value after decryption operations
            int count = 0; //temp variable to keep track of place in encryption key

            //**********Use when you want to repeat decryption code, e.g. DC = "CAT", will decrypt using CATCATCATCAT**********
            //for (int i = 0; i < stringToDecrypt.Length; i++)
            //{
            //    int cypherLoop = count % DecryptionCode.Length; //Variable to determine index of decryption code when decryption will use same code repeatedly
            //    decryptionSub = (stringToDecrypt[i] - (DecryptionCode[cypherLoop] - 64)) > 64 ? stringToDecrypt[i] - (DecryptionCode[cypherLoop] - 64) : (stringToDecrypt[i] - (DecryptionCode[cypherLoop] - 64)) + 26; //Ensure encrypted letters still have ASCII values of capital letters
            //    char character = (char)decryptionSub;
            //    decryptedString += (character.ToString());
            //    count++;
            //}

            //**********Use when you want to use entire Decryption key, then the message itself to decrypt, e.g. DC = "CAT", will decrypt using CATABCD....N where ABCD...N = first N letters of string to decrypt**********
            for (int i = 0; i < stringToDecrypt.Length; i++)
            {
                if (count < DecryptionCode.Length) //If count is shorter than decryption code length (we have not used every letter in decryption string)
                {
                    decryptionSub = (stringToDecrypt[i] - (DecryptionCode[count] - 64)) > 64 ? stringToDecrypt[i] - (DecryptionCode[count] - 64) : (stringToDecrypt[i] - (DecryptionCode[count] - 64)) + 26;
                    char character = (char)decryptionSub;
                    decryptedString += (character.ToString());
                    count++;
                }

                else //After we exhaust decryption string, start at the first letter of string to decrypt
                {
                    decryptionSub = (stringToDecrypt[i] - (decryptedString[count - DecryptionCode.Length] - 64)) > 64 ? stringToDecrypt[i] - (decryptedString[count - DecryptionCode.Length] - 64) : (stringToDecrypt[i] - (decryptedString[count - DecryptionCode.Length] - 64)) + 26;
                    char character = (char)decryptionSub;
                    decryptedString += (character.ToString());
                    count++;
                }
            }
            return decryptedString;
        }
    }
}