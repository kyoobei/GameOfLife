using UnityEngine;
using System;
using TMPro;

namespace GameOfLife.View
{
    public class ToolView : MonoBehaviour
    {
        public Action<string> OnClicked;
        public void ClickedPlay()
        {
            OnClicked?.Invoke("Play");
        }
        public void ClickedNext()
        {
            OnClicked?.Invoke("Next");
        }
        public void ClickedClear()
        {
            OnClicked?.Invoke("Clear");
        }
    }
}

