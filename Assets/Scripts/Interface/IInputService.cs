namespace GameOfLife.Interface
{
    public interface IInputService
    {
        bool TryGetGridPosition(out int x, out int y);
    }
}