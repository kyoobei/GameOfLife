using UnityEngine;

public class ShaderGridController : MonoBehaviour
{
    public int width = 64;
    public int height = 64;

    public Material gridMaterial;

    private Texture2D gridTexture;

    void Start()
    {
        gridTexture = new Texture2D(width, height, TextureFormat.RFloat, false);
        gridTexture.filterMode = FilterMode.Point;

        ClearGrid();

        gridMaterial.SetTexture("_GridTex", gridTexture);
        gridMaterial.SetVector("_GridSize", new Vector4(width, height, 0, 0));
    }

    void ClearGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridTexture.SetPixel(x, y, Color.black);
            }
        }
        gridTexture.Apply();
    }

    public void SetCell(int x, int y, bool active)
    {
        Color color = active ? Color.white : Color.black;
        gridTexture.SetPixel(x, y, color);
        gridTexture.Apply();
    }
}