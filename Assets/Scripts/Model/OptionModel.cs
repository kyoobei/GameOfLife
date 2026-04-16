using GameOfLife.Interface;

namespace GameOfLife.Model
{
    public class OptionModel : IOptionModel
    {
        private const int DEFAULT_WIDTH = 32;
        private const int DEFAULT_HEIGHT = 32;
        private const float DEFAULT_SPEED = 0.2f;
        public int Width { get; }
        public int Height { get; }
        public float Speed { get; }
        public OptionModel()
        {
            Width = DEFAULT_WIDTH;
            Height = DEFAULT_HEIGHT;
            Speed = DEFAULT_SPEED;
        }
    }
}
