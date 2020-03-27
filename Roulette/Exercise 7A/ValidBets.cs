using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7A
{
    public class ValidBets
    {
        public static SpinWheel s = new SpinWheel();
        public static List<string> WonBets = new List<string>();
        public static void AddBinNumber()
        {
            WonBets.Add(s.rCellValue < 37 ? $"Bets on {s.rCellValue} win!" : $"Bets on 00 win!");
        }

        static void AddEvenOdd()
        {
            WonBets.Add(s.rCellValue % 2 == 0 && s.rCellValue > 0 && s.rCellValue < 37 ? "Bets on even win!" : s.rCellValue % 2 != 0 && s.rCellValue > 0 && s.rCellValue < 37 ? "Bets on odd win!" : "\b");          
        }

        static void AddBlackRed()
        {
            WonBets.Add(s.rCellColor == "Black" ? "Bets on black win!" : s.rCellColor == "Red" ? $"Bets on red win!" : "\b");
        }

        static void AddHighLow()
        {
            WonBets.Add(s.rCellValue <= 18 && s.rCellValue > 0 && s.rCellValue < 37 ? "Bets on low win!" : s.rCellValue > 18 && s.rCellValue < 37 ? "Bets on high win!" : "\b");
        }

        static void AddDozens()
        {
            WonBets.Add(s.rCellValue <= 12 && s.rCellValue > 0 && s.rCellValue < 37 ? "Bets on 1 - 12 win!" : s.rCellValue > 12 && s.rCellValue <= 24 ? "Bets on 13 - 24 win!" : s.rCellValue > 24 && s.rCellValue < 37 ? "Bets on 25 - 36 win!" : "\b");
        }

        static void AddColumns()
        {
            WonBets.Add(s.rCellValue > 0 && s.rCellValue < 37 ? $"Bets on the {(s.rCellValue - 1) % 3 + 1} column win!" : "\b");
        }

        static void AddStreets()
        {
            WonBets.Add(s.rCellValue > 0 && s.rCellValue < 37 ? $"Bets on the {(s.rCellValue - 1) / 3 + 1} column win!" : "\b");
        }

        static void AddSixNumbers()
        {
            if (s.rCellValue > 3 && s.rCellValue < 34)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 5} / {s.rCellValue - 2} Six Line win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 2} / {s.rCellValue + 1} Six Line win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} Six Line win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} Six Line win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 4} / {s.rCellValue - 1} Six Line win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue + 2} Six Line win!");
                }
            }
            else if (s.rCellValue > 0 && s.rCellValue <= 3)
            {
                WonBets.Add($"Bets on the 1 / 4 Six Line win!");
            }
            else if (s.rCellValue >= 34 && s.rCellValue < 37)
            {
                WonBets.Add($"Bets on the 31 / 37 Six Line win!");
            }
        }

        static void AddSplit()
        {
            if (s.rCellValue > 3 && s.rCellValue < 34)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
            }
            else if (s.rCellValue > 0 && s.rCellValue <= 3)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 3} split win!");
                }
            }
            else if (s.rCellValue >= 34 && s.rCellValue < 37)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} split win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} split win!");
                }
            }
        }

        static void AddCorner()
        {
            if (s.rCellValue > 3 && s.rCellValue < 34)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 4} / {s.rCellValue - 3} / {s.rCellValue - 1} / {s.rCellValue} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} / {s.rCellValue + 2} / {s.rCellValue + 3} corner win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue - 2} / {s.rCellValue} / {s.rCellValue + 1} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} / {s.rCellValue + 3} / {s.rCellValue + 4} corner win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 4} / {s.rCellValue - 3} / {s.rCellValue - 1} / {s.rCellValue} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue - 2} / {s.rCellValue} / {s.rCellValue + 1} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} / {s.rCellValue + 2} / {s.rCellValue + 3} corner win!");                    
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} / {s.rCellValue + 3} / {s.rCellValue + 4} corner win!");
                }
            }
            else if (s.rCellValue > 0 && s.rCellValue <= 3)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} / {s.rCellValue + 2} / {s.rCellValue + 3} corner win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} / {s.rCellValue + 3} / {s.rCellValue + 4} corner win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 1} / {s.rCellValue} / {s.rCellValue + 2} / {s.rCellValue + 3} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue} / {s.rCellValue + 1} / {s.rCellValue + 3} / {s.rCellValue + 4} corner win!");
                }
            }
            else if (s.rCellValue >= 34 && s.rCellValue < 37)
            {
                if (s.rCellValue % 3 == 0)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 4} / {s.rCellValue - 3} / {s.rCellValue - 1} / {s.rCellValue} corner win!");
                }
                else if (s.rCellValue % 3 == 1)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue - 2} / {s.rCellValue} / {s.rCellValue + 1} corner win!");
                }
                else if (s.rCellValue % 3 == 2)
                {
                    WonBets.Add($"Bets on the {s.rCellValue - 4} / {s.rCellValue - 3} / {s.rCellValue - 1} / {s.rCellValue} corner win!");
                    WonBets.Add($"Bets on the {s.rCellValue - 3} / {s.rCellValue - 2} / {s.rCellValue} / {s.rCellValue + 1} corner win!");
                }
            }
        }
        public static void AddValidBets()
        {
            Console.WriteLine($"The winning number is: {(s.rCellValue < 37 ? s.rCellValue.ToString() : "00")}, {s.rCellColor}");
            Console.WriteLine("That means that:");
            AddBinNumber();
            AddEvenOdd();
            AddBlackRed();
            AddHighLow();
            AddDozens();
            AddColumns();
            AddStreets();
            AddSixNumbers();
            AddSplit();
            AddCorner();

            foreach (string wonBet in WonBets)
            {
                Console.WriteLine(wonBet);
            }
        }
    }
}
