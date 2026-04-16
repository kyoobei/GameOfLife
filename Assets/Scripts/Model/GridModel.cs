using UnityEngine;
using GameOfLife.Interface;

namespace GameOfLife.Model
{
    public class GridModel : IGridModel
    {
        private int width;
        private int height;
        private bool[,] cells;

        public int Width => width;
        public int Height => height;

        public GridModel(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new bool[width, height];
        }
        public void SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new bool[width, height];
        }
        public bool GetCell(int x, int y)
        {
            if (!IsValid(x, y)) return false;
            return cells[x, y];
        }
        public void SetCell(int x, int y, bool value)
        {
            if (!IsValid(x, y)) return;
            cells[x, y] = value;
        }
        public void Clear()
        {
            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                cells[x, y] = false;
        }

        private bool IsValid(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }
    }
}
