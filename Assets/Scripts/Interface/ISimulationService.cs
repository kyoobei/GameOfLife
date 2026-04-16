namespace GameOfLife.Interface
{
    public interface ISimulationService
    {
        void Tick(IGridModel model);
    }
}