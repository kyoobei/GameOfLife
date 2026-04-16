using GameOfLife.Interface;
namespace GameOfLife.Model
{
    public class ToolModel : IToolModel
    {
        public bool IsPlaying 
        {
            get
            {
                return isPlaying;
            }
        }

        private bool isPlaying = false;

        public void TogglePlay()
        {
            isPlaying = !isPlaying;
        }
    }
}