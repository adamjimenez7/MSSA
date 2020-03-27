using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise_8A
{
    class Program
    {
        static void Main(string[] args)
        {
            //BisectionInAction newGame = new BisectionInAction();
            //newGame.AutomaticBisection();

            GamePlay newGame = new GamePlay();
            newGame.GameSelect();
        }
    }
}
