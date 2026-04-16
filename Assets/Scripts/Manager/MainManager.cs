using UnityEngine;
using GameOfLife.Presenter;
namespace GameOfLife.Manager
{
    public class MainManager : MonoBehaviour
    {
        [SerializeField]
        private UIPresenter uiPresenter;
        [SerializeField]
        private GridPresenter gridPresenter;

        #region UNITY METHODS
        private void Start()
        {
            uiPresenter.OnReceivedPlay += HandlePlayStateChanged;
            uiPresenter.OnReceivedNext += HandleNext;
            uiPresenter.OnReceivedReset += HandleReset;

            uiPresenter.OnReceivedOptionChanged += HandleOptionChanged;
        }
        private void OnDisable()
        {
            uiPresenter.OnReceivedPlay -= HandlePlayStateChanged;
            uiPresenter.OnReceivedNext -= HandleNext;
            uiPresenter.OnReceivedReset -= HandleReset;

            uiPresenter.OnReceivedOptionChanged -= HandleOptionChanged;
        }
        #endregion

        #region LISTENERS FOR OPTIONS
        private void HandlePlayStateChanged(bool isPlaying)
        {
            gridPresenter.SetSimulationState(isPlaying);
        }
        private void HandleNext()
        {
            gridPresenter.Next();
        }
        private void HandleReset()
        {
            gridPresenter.Reset();
        }
        #endregion

        #region LISTENERS FOR TOOLS
        private void HandleOptionChanged(int width, int height, float speed)
        {
            gridPresenter.UpdateGrid(width, height, speed);
        }
        #endregion
    }
}