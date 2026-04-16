using UnityEngine;
using GameOfLife.View;
using GameOfLife.Model;
using System;

namespace GameOfLife.Presenter
{
    public class UIPresenter : MonoBehaviour
    {
        [SerializeField]
        private ToolView toolView;
        [SerializeField]
        private OptionView optionView;
        private ToolModel toolModel;
        private OptionModel optionModel;

        public Action<bool> OnReceivedPlay;
        public Action OnReceivedNext;
        public Action OnReceivedReset;
        public Action<int, int, float> OnReceivedOptionChanged;

        #region UNITY METHODS
        private void Awake()
        {
            toolModel = new ToolModel();
            optionModel = new OptionModel();
        }
        private void Start()
        {
            toolView.Initialize();

            // listeners
            toolView.OnClickedPlay += ReceivedPlayClicked;
            toolView.OnClickedNext += ReceivedNextClicked;
            toolView.OnClickedReset += ReceivedResetClicked;

            optionView.OnReceivedOptionChanged += ReceivedOptionChanged;

            optionView.SetInitialValues(
                optionModel.Width, 
                optionModel.Height, 
                optionModel.Speed
            );
        }
        private void OnDisable()
        {
            toolView.OnClickedPlay -= ReceivedPlayClicked;
            toolView.OnClickedNext -= ReceivedNextClicked;
            toolView.OnClickedReset -= ReceivedResetClicked;

            optionView.OnReceivedOptionChanged -= ReceivedOptionChanged;           
        }
        #endregion

        private void ReceivedPlayClicked()
        {
            toolModel.TogglePlay();
            toolView.SetPlayState(toolModel.IsPlaying);
            OnReceivedPlay?.Invoke(toolModel.IsPlaying);
        }
        private void ReceivedNextClicked()
        {
            OnReceivedNext?.Invoke();
        }
        private void ReceivedResetClicked()
        {
            OnReceivedReset?.Invoke();
        }
        private void ReceivedOptionChanged(int width, int height, float speed)
        {
            OnReceivedOptionChanged?.Invoke(width, height, speed);
        }
    }
}