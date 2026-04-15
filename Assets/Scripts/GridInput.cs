using UnityEngine;

public class GridInput : MonoBehaviour
{
    public Camera cam;
    public ShaderGridController grid;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector2 uv = hit.textureCoord;

                int x = Mathf.FloorToInt(uv.x * grid.width);
                int y = Mathf.FloorToInt(uv.y * grid.height);

                grid.SetCell(x, y, true);
            }
        }
    }
}