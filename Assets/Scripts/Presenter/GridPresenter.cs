using UnityEngine;
using GameOfLife.View;
using GameOfLife.Model;
using GameOfLife.Service;

namespace GameOfLife.Presenter
{
    public class GridPresenter : MonoBehaviour
    {
        [SerializeField] 
        private GridView gridView;
        [SerializeField] 
        private Camera targetCamera;

        private int width = 64;
        private int height = 64;
        private float tickInterval = 0.2f;
        private float timer;

        private GridModel model;
        private InputService input;
        private SimulationService simulation;

        private bool dirty;
        private bool isPlaying;
        private bool isInitialized;

        #region UNITY METHODS
        private void Awake()
        {
            simulation = new SimulationService();
        }
        private void Update()
        {
            if (!isInitialized) return;
            
            UpdateInput();
            UpdateSimulation();
        }
        private void LateUpdate()
        {
            if (!isInitialized) return;

            if (dirty)
            {
                // control the redraw frequency to improve performance
                DrawCell();
                gridView.Apply();
                dirty = false;
            }
        }
        #endregion
        public void UpdateGrid(int width, int height, float speed)
        {
            this.width = width;
            this.height = height;
            
            tickInterval = speed;

            model = new GridModel(width, height);
            input = new InputService(targetCamera, width, height);
            gridView.Initialize(width, height);

            dirty = true;
            isInitialized = true;
        }
        public void SetSimulationState(bool isPlaying)
        {
            this.isPlaying = isPlaying;
        }
        public void Next()
        {
            simulation.Tick(model);
            dirty = true;
        }
        public void Reset()
        {
            model.Clear();
            gridView.Clear();
        }
        private void UpdateInput()
        {
            if (input.TryGetGridPosition(out int x, out int y))
            {
                model.SetCell(x, y, true);
                gridView.SetCell(x, y, true);
                dirty = true;
            }
        }
        private void UpdateSimulation()
        {
            if (!isPlaying) return;

            timer += Time.deltaTime;

            if (timer >= tickInterval)
            {
                timer = 0f;
                simulation.Tick(model);
                dirty = true;
            }
        }
        private void DrawCell()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    gridView.SetCell(x, y, model.GetCell(x, y));
                }
            }
        }
    }
}
