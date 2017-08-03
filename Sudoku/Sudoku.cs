﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        internal Dictionary<int, List<int>> rows = new Dictionary<int, List<int>>();
        internal Dictionary<int, List<int>> columns = new Dictionary<int, List<int>>();
        internal Dictionary<int, List<int>> grids = new Dictionary<int, List<int>>();
        public List<SudokuNumber> entries = new List<SudokuNumber>();

        internal Sudoku()
        {
            for(int index = 1; index<10; index++)
            {
                    rows.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                    //index == row #
                    columns.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9});
                    //index == column #
                    grids.Add(index, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }); 
                    //index == grid # correspending to the alphabet
            }
            for(int row = 1; row<10; row++)
            {
                for(int col = 1; col<10; col++)
                {
                    entries.Add(new SudokuNumber(row, col, null));
                    
                }
            }
        }      

        public void AddNumber(int row, int column, int? value)
        {
            int grid;
            entries.Add(new SudokuNumber(row, column, value));

            if (value != null)
            {
                RemovePossibilities(row, column, (int)value);
            }
        }

        public void RemovePossibilities(int row, int column, int value)
        {
            int grid = (int)((Math.Ceiling((double)row / 3) - 1) * 3 + Math.Ceiling((double)column / 3));
            rows[row].Remove(value);
            columns[column].Remove(value);
            grids[grid].Remove(value);
        }
    }
}
