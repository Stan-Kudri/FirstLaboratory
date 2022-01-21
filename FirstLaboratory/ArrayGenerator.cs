using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLaboratory
{
    public class ArrayGenerator
    {
        private readonly int _column;
        private readonly int _row;
        private readonly int _amountElements;

        public string timeOneDimensionArray { get; set; }
        public string timeTwoDimensionArray { get; set; }
        public string timeJaggedArray { get; set; }

        public ArrayGenerator(int column, int row)
        {
            _column = column;
            _row = row;
            _amountElements = column * row;
        }

        public int [] OneDimensionalArray()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();            
            var array = new int[_amountElements];
            for (var i = 0; i < _amountElements; i++)
            {
                array[i] = Random.Shared.Next(-5, 5);
            }
            stopwatch.Stop();
            timeOneDimensionArray = stopwatch.ElapsedTicks.ToString();
            return array;
        }

        public int[,] TwoDimensionalArray()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var array = new int [_row, _column];
            for (var i = 0; i < _row; i++)
            {
                for (var j = 0; j < _column; j++)
                {
                    array[i, j] = Random.Shared.Next(-5, 5);
                }
            }
            stopwatch.Stop();
            timeTwoDimensionArray = stopwatch.ElapsedTicks.ToString();
            return array;
        }
        public int [][] JaggedGenerate()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var generateArray = new int[_row][];
            for (var i = 0; i < _row; i++)
            {
                generateArray[i] = new int[_column];
                for (var j = 0; j < _column; j++)
                {
                    generateArray[i][j] = Random.Shared.Next(-5, 5);
                }
            }
            stopwatch.Stop();
            timeJaggedArray = stopwatch.ElapsedTicks.ToString();
            return generateArray;
        }
    }
}
