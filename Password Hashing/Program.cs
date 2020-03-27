using System;
using System.Collections.Generic;

namespace Exercise_9A
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to Adam's Account Manager.");
            Session newSesh = new Session();
            newSesh.StartSession();
        }
    }
}