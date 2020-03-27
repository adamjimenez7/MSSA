using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7A
{
    public class SpinWheel
    {
        public int rCellValue { get; set; }
        public string rCellColor { get; set; }

        public SpinWheel()
        {
            RouletteBoard board = new RouletteBoard();
            Random r = new Random();

            int rSpin = r.Next(0, 38);
            if (rSpin == 0)
            {
                rCellValue = 0;
                rCellColor = "Green";
            }
            else if (rSpin == 37)
            {
                rCellValue = 37;
                rCellColor = "Green";
            }
            else
            {
                foreach (Cell cell in board.GridCells)
                {
                    if (cell.Value == rSpin)
                    {
                        rCellValue = cell.Value;
                        rCellColor = cell.Color.ToString();
                    }
                }
            }
        }

        public void showCell()
        {
            Console.WriteLine($"Cell value: {rCellValue}");
            Console.WriteLine($"Cell color: {rCellColor}");
        }
    }
}
