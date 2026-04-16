using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

namespace GameOfLife.View
{
    public class ToolView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField]
        private Button btnPlay;
        [SerializeField]
        private Button btnNext;

        [Header("UI Text")]
        [SerializeField]
        private TMP_Text txtPlay;
        [SerializeField]
        private TMP_Text txtAlive;
        [SerializeField]
        private TMP_Text txtGeneration;

        public Action OnClickedPlay;
        public Action OnClickedNext;
        public Action OnClickedReset;

        public void Initialize()
        {
            SetPlayState(false);
        }
        public void SetPlayState(bool playing)
        {
            btnNext.interactable = !playing;
            txtPlay.text = playing ? "Pause" : "Play";
        }
        public void SetStats(int aliveCount, int generationCount)
        {
            txtAlive.text = aliveCount.ToString();
            txtGeneration.text = generationCount.ToString();
        }

        #region UNITY UI EVENTS
        public void ClickedPlay()
        {
            OnClickedPlay?.Invoke();
        }
        public void ClickedNext()
        {
            OnClickedNext?.Invoke();
        }
        public void ClickedReset()
        {
            OnClickedReset?.Invoke();
        }
        #endregion
    }
}

