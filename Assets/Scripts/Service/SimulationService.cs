using GameOfLife.Interface;
namespace GameOfLife.Service
{
    public class SimulationService : ISimulationService
    {
        public void Tick(IGridModel model)
        {
            int width = model.Width;
            int height = model.Height;

            bool[,] next = new bool[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbors = CountNeighbors(model, x, y);
                    bool isAlive = model.GetCell(x, y);

                    if (isAlive)
                    {
                        next[x, y] = neighbors == 2 || neighbors == 3;
                    }
                    else
                    {
                        next[x, y] = neighbors == 3;
                    }
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    model.SetCell(x, y, next[x, y]);
                }
            }
        }

        private int CountNeighbors(IGridModel model, int x, int y)
        {
            int count = 0;

            for (int neighborX = -1; neighborX <= 1; neighborX++)
            {
                for (int neighborY = -1; neighborY <= 1; neighborY++)
                {
                    if (neighborX == 0 && neighborY == 0) 
                        continue;

                    if (model.GetCell(x + neighborX, y + neighborY))
                        count++;
                }
            }

            return count;
        }
    }
}