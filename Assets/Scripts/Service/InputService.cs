using UnityEngine;
using GameOfLife.Interface;

namespace GameOfLife.Service
{
    public class InputService : IInputService
    {
        private Camera cam;
        private int width;
        private int height;

        public InputService(Camera cam, int width, int height)
        {
            this.cam = cam;
            this.width = width;
            this.height = height;
        }

        public bool TryGetGridPosition(out int x, out int y)
        {
            x = y = 0;

            if (!Input.GetMouseButton(0)) return false;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2 uv = hit.textureCoord;

                x = Mathf.FloorToInt(uv.x * width);
                y = Mathf.FloorToInt(uv.y * height);
                return true;
            }

            return false;
        }
    }
}