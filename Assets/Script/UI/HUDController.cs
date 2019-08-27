using System;
using Script.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HUDController : MonoBehaviour
    {
        private GameController gameController;
        private Canvas canvas;
        private Text text;


        private void Start()
        {
            UpdateVisibility(gameController.GameState);
            updateScore(gameController.Score);
            
        }
        private void Awake()
        {
            text = GetComponentInChildren<Text>();
            gameController = Finder.GameController;
            canvas =  GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            gameController.OnGameStateChanged += UpdateVisibility;
            gameController.OnScoreChanged += updateScore;
        }

        private void OnDisable()
        {
            gameController.OnGameStateChanged -= UpdateVisibility;
            gameController.OnScoreChanged -= updateScore;
        }

        private void UpdateVisibility(GameState gameState)
        {
            canvas.enabled = gameState == GameState.Playing;
        }

        private void Update()
        {
        }

        private void updateScore(int newScore)
        {
            text.text = newScore.ToString("00");
        }
    }
}