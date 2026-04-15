namespace GameOfLife.Interface
{
    public interface IGridModel
    {
        int Width { get; }
        int Height { get; }

        void SetSize(int width, int height);
        void SetCell(int x, int y, bool active);
        bool GetCell(int x, int y);
        void Clear();
    }
}