using UnityEngine;
using System;

namespace GameOfLife.View
{
    public class OptionView : MonoBehaviour
    {
        public Action<string, int> OnValueChanged;

        public void OnWidthChanged(string value)
        {
            int width = int.Parse(value);
            OnValueChanged?.Invoke("Width", width);
        }
        public void OnHeightChanged(string value)
        {
            int height = int.Parse(value);
            OnValueChanged?.Invoke("Height", height);
        }
    }
}