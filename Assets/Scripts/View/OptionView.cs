using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

namespace GameOfLife.View
{
    public class OptionView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private TMP_InputField inputWidth;
        [SerializeField]
        private TMP_InputField inputHeight;
        [SerializeField]
        private Slider sliderSpeed;

        private int lastWidth;
        private int lastHeight;
        private float lastSpeed;

        public Action<int, int, float> OnReceivedOptionChanged;

        private void Start()
        {
            sliderSpeed.onValueChanged.AddListener(UpdateSpeed);
            inputWidth.onValueChanged.AddListener(UpdateWidth);
            inputHeight.onValueChanged.AddListener(UpdateHeight);
        }
        private void OnDisable()
        {
            sliderSpeed.onValueChanged.RemoveListener(UpdateSpeed);
            inputWidth.onValueChanged.RemoveListener(UpdateWidth);
            inputHeight.onValueChanged.RemoveListener(UpdateHeight);
        }
        public void SetInitialValues(int width, int height, float speed)
        {
            inputWidth.text = width.ToString();
            inputHeight.text = height.ToString();

            lastWidth = width;
            lastHeight = height;
            lastSpeed = speed;
            OnReceivedOptionChanged?.Invoke(width, height, speed);
        }
        public void UpdateWidth(string value)
        {
            if(string.IsNullOrEmpty(value) || value == "0")
                return;

            int width = int.Parse(value);
            lastWidth = width;
            OnReceivedOptionChanged?.Invoke(lastWidth, lastHeight, lastSpeed);
        }
        public void UpdateHeight(string value)
        {
            if(string.IsNullOrEmpty(value) || value == "0")
                return;

            int height = int.Parse(value);
            lastHeight = height;
            OnReceivedOptionChanged?.Invoke(lastWidth, lastHeight, lastSpeed);
        }
        public void UpdateSpeed(float value)
        {
            lastSpeed = value;
            OnReceivedOptionChanged?.Invoke(lastWidth, lastHeight, lastSpeed);
        }
    }
}