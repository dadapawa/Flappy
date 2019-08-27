using UnityEngine;

namespace Game
{
    public class GameOverMenuController : MonoBehaviour
    {
        private GameController gameController;
        private Canvas canvas;


        private void stat()
        {
            UpdateVisibility(gameController.GameState);
        }
        private void Awake()
        {
            gameController = Finder.GameController;
            canvas =  GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            gameController.OnGameStateChanged += UpdateVisibility;
        }

        private void OnDisable()
        {
            gameController.OnGameStateChanged -= UpdateVisibility;
        }

        private void UpdateVisibility(GameState gameState)
        {
            //equals to  (is gameState == Mainmenu)
            canvas.enabled = gameState == GameState.GameOver;
        }
    }
}