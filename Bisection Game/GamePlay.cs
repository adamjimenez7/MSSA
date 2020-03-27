using System;

namespace Exercise_8A
{
    class GamePlay
    {
        public int Val { get; set; }
        public int Guess { get; set; }
        public void GameSelect() //Player chooses to play themselves or let the computer guess
        {
            System.Console.WriteLine("Welcome to the \"Guess My Number\" game!");
            System.Console.WriteLine("What gameplay would you like to do?");
            System.Console.WriteLine(@"
            1. I want to guess a number!
            2. I want the computer to guess a number!
            3. I am done playing for now. I want to exit.");
            char userInput = Console.ReadKey().KeyChar;
            System.Console.WriteLine("\n");
            try
            {
                if (Char.GetNumericValue(userInput) < 1 || Char.GetNumericValue(userInput) > 3) //Checking for invalid user input
                {
                    throw new IndexOutOfRangeException("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
                }

                if (userInput == '1')
                {
                    GameInit(userInput); //Sends player to choose array parameters with a char "cookie" to remember their game selection
                }

                else if (userInput == '2')
                {
                    GameInit(userInput); //Sends player to choose array parameters with a char "cookie" to remember their game selection
                }

                else if (userInput == '3')
                {
                    Environment.Exit(0); //Exits console app
                }
            }

            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
            }
        }
        public void GameInit(char gameSelect) //Player chooses the parameters to work with, passing in a char as a "cookie" to then go to the correct gameplay previously selecter
        {
            try //Ensuring parameters are appropriate
            {
                System.Console.WriteLine("To start, please enter what you want for the lower limit of possible numbers: ");
                int lowParam = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Now, please enter what you want for the upper limit of possible numbers: ");
                int hiParam = int.Parse(Console.ReadLine());

                if(lowParam > hiParam) //Ensuring lower parameter is not larger than upper parameter switiching them if it is
                {
                    System.Console.WriteLine("Uh oh, lower parameter is larger than the upper parameter!");
                    System.Console.WriteLine("Easy fix: your lower parameter is now your upper parameter, and vice-versa");
                    int tempParam = lowParam;
                    lowParam = hiParam;
                    hiParam = tempParam;
                }

                else if(lowParam == hiParam) //If lower parameter and upper parameter are equal, changing them to 1 and 1000 respectively
                {
                    System.Console.WriteLine("Uh oh, lower parameter is the same as the upper parameter!");
                    System.Console.WriteLine("To ensure we can still play, your lower paramter is now \"1\" and your upper parameter is now \"1000\".");
                    lowParam = 1;
                    hiParam = 1000;
                }

                if(gameSelect == '1')
                    {
                        StartPlayerGame(lowParam, hiParam); //Begin player plays method using char "cookie"
                    }
                else if(gameSelect == '2')
                    {
                        StartComputerGame(lowParam, hiParam); //Begin computer plays method using char "cookie"
                    }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input only integer values.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Invalid entry. Please input a number and then press \"enter\"");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Invalid entry, number too large. Please input a valid number and then press \"enter\"");
            }
        }
        
        public void StartPlayerGame(int lowParam, int hiParam) //Player plays method
        {
            ArrayConfig newArray = new ArrayConfig(); //Creating ArrayConfig object to manipulate the array and use bisection methods
            newArray.CreateArray(lowParam, hiParam); //Initializing the array
            Random r = new Random();
            Val = r.Next(newArray.WorkingArray[0], newArray.WorkingArray[newArray.WorkingArray.Length - 1] + 1); //Generatting random number within the parameters of array to act as the value the player must guess

            System.Console.WriteLine("--------------------- Player Guess ---------------------");
            System.Console.WriteLine("Please make your first guess: ");
            int guessCount = 1;
            Guess = int.Parse(Console.ReadLine());
            while(Guess != Val && newArray.WorkingArray.Length > 1) //While the player is guessing...
            try
            {
                if (Guess < Val)
                {
                    System.Console.WriteLine("You are too low!");
                    System.Console.WriteLine("Please guess again: ");
                    guessCount++;
                    Guess = int.Parse(Console.ReadLine());
                }

                else if (Guess > Val)
                {
                    System.Console.WriteLine("You are too high!");
                    System.Console.WriteLine("Please guess again: ");
                    guessCount++;
                    Guess = int.Parse(Console.ReadLine());
                }
            }
            
            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input a number and then press \"enter\"");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Invalid entry. Please input a number and then press \"enter\"");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Invalid entry. Please input a number and then press \"enter\"");
            }

            if (newArray.WorkingArray.Length == 1)
            {
                System.Console.WriteLine("You failed to guess the number...");
                System.Console.WriteLine($"The value was {Val}, and you made {guessCount} guesses");
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                WinningMenu('1'); //Send player to menu to either quit or keep playing
            }

            if (Guess == Val)
            {
                System.Console.WriteLine("Excellent guess! You win!");
                System.Console.WriteLine($"You guessed the value {Val} in {guessCount} guesses!");
                System.Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                WinningMenu('1'); //Send player to menu to either quit or keep playing
            }
        }
        public void StartComputerGame(int lowParam, int hiParam) //Computer plays method
        {
            ArrayConfig newArray = new ArrayConfig(); //Creating ArrayConfig object to manipulate the array and use bisection methods
            newArray.CreateArray(lowParam, hiParam);
            Random r = new Random(); //Setting the stage to create random computer guesses
            Guess = r.Next(newArray.WorkingArray[0], newArray.WorkingArray[newArray.WorkingArray.Length - 1] + 1); //Generatting random number within the parameters of array to act as the computer's guess
            System.Console.WriteLine("--------------------- Computer Guess ---------------------");
            System.Console.WriteLine($"The computer's first guess is: {Guess}");
            int guessCount = 1;
            
            guessLoop:
            System.Console.WriteLine("Was the computer's guess:");
            System.Console.WriteLine(@"
            1. High
            2. Low
            3. Right on the money");
            char userInput = Console.ReadKey().KeyChar;
            System.Console.WriteLine("\n");
            try
            {
                if (Char.GetNumericValue(userInput) < 1 || Char.GetNumericValue(userInput) > 3) //Checking for invalid user input
                {
                    throw new IndexOutOfRangeException("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
                }

                if (userInput == '1')
                {
                    if (newArray.WorkingArray.Length > 1) //Ensuring there is room in the array to resize
                    {
                        int arrayLower = newArray.WorkingArray[0]; //Determine the current lower parameter of the working array
                        newArray.CreateArray(arrayLower, Guess - 1); //Create array with params based off user input
                        System.Console.WriteLine($"The array is now from {newArray.WorkingArray[0]} to {newArray.WorkingArray[newArray.WorkingArray.Length - 1]}.");
                        System.Console.WriteLine("Now to guess again...");
                        Guess = r.Next(newArray.WorkingArray[0], newArray.WorkingArray[newArray.WorkingArray.Length - 1] + 1); //New guess from the computer
                        guessCount ++; //Increment guess counter
                        System.Console.WriteLine($"The computer's next guess is: {Guess}");
                        goto guessLoop;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The number was not in the array...");
                        System.Console.WriteLine($"The computer made {guessCount} guesses to get to this point");
                        System.Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        WinningMenu('1'); //Send player to menu to either quit or keep playing;
                    }
                }
                else if (userInput == '2')
                {
                    if (newArray.WorkingArray.Length > 1) //Ensuring there is room in the array to resize
                    {
                        int arrayUpper = newArray.WorkingArray[newArray.WorkingArray.Length - 1]; //Determine the current upper parameter of the working array
                        newArray.CreateArray(Guess + 1, arrayUpper); //Create array with params based off user input
                        System.Console.WriteLine($"The array is now from {newArray.WorkingArray[0]} to {newArray.WorkingArray[newArray.WorkingArray.Length - 1]}.");
                        System.Console.WriteLine("Now to guess again...");
                        Guess = r.Next(newArray.WorkingArray[0], newArray.WorkingArray[newArray.WorkingArray.Length - 1] + 1); //New guess from the computer
                        guessCount++; //Increment guess counter
                        System.Console.WriteLine($"The computer's next guess is: {Guess}");
                        goto guessLoop;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("The number was not in the array...");
                        System.Console.WriteLine($"The computer made {guessCount} guesses to get to this point");
                        System.Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        WinningMenu('1'); //Send player to menu to either quit or keep playing;
                    }
                }
                else if (userInput == '3')
                {
                    System.Console.WriteLine("Yay!");
                    System.Console.WriteLine($"The computer made {guessCount} guesses to get to this point");
                    WinningMenu('2'); //Sends player to next menu
                }
            }
            
            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("We are out of range of the array.");
            }

            if (newArray.WorkingArray.Length == 1) //If array only contains one item and it is not what the user selected...
                {
                    System.Console.WriteLine("The number was not in the array...");
                    System.Console.WriteLine($"The computer made {guessCount} guesses to get to this point");
                    System.Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    WinningMenu('2'); //Send player to menu to either quit or keep playing
                }
        } 

        public void WinningMenu(char prevGame)
        {
            System.Console.WriteLine("What would you like to do now? Please enter a number: "); //Allows user to play again or close
            System.Console.WriteLine(@"
            1. Play again
            2. Return to main menu
            3. Exit");
            char userInput = Console.ReadKey().KeyChar;
            System.Console.WriteLine("\n");
            try
            {
                
                if (Char.GetNumericValue(userInput) < 1 || Char.GetNumericValue(userInput) > 3) //Checking for invalid user input
                {
                    throw new IndexOutOfRangeException("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
                }
                
                if (userInput == '1')
                {
                    GameInit(prevGame);
                }

                else if (userInput == '2')
                {
                    GameSelect();
                }

                else if (userInput == '3')
                {
                    Environment.Exit(0);
                }
            }

            catch (FormatException e)
            {
                Console.WriteLine("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Invalid entry. Please input only the number \"1\", \"2\" or \"3\" (without quotes).");
            }
        }
    }
}