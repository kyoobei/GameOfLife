using UnityEngine;
using GameOfLife.Interface;

namespace GameOfLife.View
{
    public class GridView : MonoBehaviour, IGridView
    {
        [SerializeField] 
        private Material material;

        private Texture2D texture;
        private int width;
        private int height;

        public void Initialize(int width, int height)
        {
            this.width = width;
            this.height = height;

            texture = new Texture2D(width, height, TextureFormat.RFloat, false);
            texture.filterMode = FilterMode.Point;

            material.SetTexture("_GridTex", texture);
            material.SetVector("_GridSize", new Vector4(width, height, 0, 0));

            Clear();
        }

        public void SetCell(int x, int y, bool value)
        {
            texture.SetPixel(x, y, value ? Color.white : Color.black);
        }

        public void Apply()
        {
            texture.Apply();
        }

        public void Clear()
        {
            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                texture.SetPixel(x, y, Color.black);

            texture.Apply();
        }
    }
}
