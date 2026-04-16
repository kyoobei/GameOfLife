namespace GameOfLife.Interface
{
    public interface IToolModel
    {
        bool IsPlaying { get; }
        void TogglePlay();
    }
}