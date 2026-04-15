namespace GameOfLife.Interface
{
    public interface IGridView
    {
        void Initialize(int width, int height);
        void SetCell(int x, int y, bool value);
        void Apply();
        void Clear();
    }
}