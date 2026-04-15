using UnityEngine;
using GameOfLife.View;
using GameOfLife.Interface;
using GameOfLife.Model;
using GameOfLife.Service;

namespace GameOfLife.Presenter
{
    public class GridPresenter : MonoBehaviour
    {
        [Header("Config")]
        public int width = 64;
        public int height = 64;

        [Header("References")]
        [SerializeField] private GridView viewComponent;
        [SerializeField] private Camera cam;

        private IGridModel model;
        private IGridView view;
        private IInputService input;

        private bool dirty;

        void Awake()
        {
            // Dependency Injection (manual)
            model = new GridModel(width, height);
            view = viewComponent;
            input = new InputService(cam, width, height);
        }

        void Start()
        {
            view.Initialize(width, height);
        }

        void Update()
        {
            HandleInput();
        }

        void LateUpdate()
        {
            if (dirty)
            {
                view.Apply();
                dirty = false;
            }
        }

        private void HandleInput()
        {
            if (input.TryGetGridPosition(out int x, out int y))
            {
                if (!model.GetCell(x, y))
                {
                    model.SetCell(x, y, true);
                    view.SetCell(x, y, true);
                    dirty = true;
                }
            }
        }

        // Optional public API (for AI, networking, etc.)
        public void SetCell(int x, int y, bool value)
        {
            if (model.GetCell(x, y) == value) return;

            model.SetCell(x, y, value);
            view.SetCell(x, y, value);
            dirty = true;
        }

        public void ClearGrid()
        {
            model.Clear();
            view.Clear();
        }
    }
}
