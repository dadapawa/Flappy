using System;
using System.Collections;
using Script.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private GameState gameState = GameState.MainMenu;
        private PlayerDeathEventChannel playerDeathEventChannel;
        private ScoreEventChannel scoreEventChannel;
        private int score;
        public GameState GameState
        {
            get { return gameState;}
            private set
            {
                if (gameState != value)
                {
                    gameState = value;
                    NotifyGameStateChanged();
                }
            }
        }

        public int Score => score;
        

        private void NotifyGameStateChanged()
        {
            if (OnGameStateChanged != null) OnGameStateChanged(gameState);
        }

        
        private void Awake()
        {
            playerDeathEventChannel = Finder.PlayerDeathEventChannel;
            scoreEventChannel = Finder.ScoreEventChannel;
            score = 0;
        }

        public event GameStateChangedEventHandler OnGameStateChanged;
        public event GameScoreChangedEventHandler OnScoreChanged;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && GameState == GameState.MainMenu)
            {
                //if (OnGameStateChanged != null) OnGameStateChanged(GameState.Playing);
                GameState = GameState.Playing;
            }

            if (Input.GetKeyDown(KeyCode.Space) && GameState == GameState.GameOver)
                RestartGame();
        }


        public void RestartGame()
        {
            GameState = Game.GameState.MainMenu;
            score = 0;
            StartCoroutine(ReloadGame());
        }

        public IEnumerator ReloadGame()
        {
            yield return UnLoadGame();
            yield return LoadGame();
        }
        private void Start()
        {
            if(!SceneManager.GetSceneByName(Scenes.GAME).isLoaded)
                StartCoroutine(LoadGame());
        }

        
        private IEnumerator UnLoadGame()
        {
            yield return  SceneManager.UnloadSceneAsync(Scenes.GAME);
        }
        
        private IEnumerator LoadGame()
        {
            //Show loading screen
            yield return SceneManager.LoadSceneAsync(Scenes.GAME, LoadSceneMode.Additive);
            //Hide loading screen
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.GAME));
        }

        private void OnDisable()
        {
            playerDeathEventChannel.OnPlayerDeath -= EndGame;
            scoreEventChannel.OnScoreEvent -= Scored;
        }
        private void OnEnable()
        {
            playerDeathEventChannel.OnPlayerDeath += EndGame;
            scoreEventChannel.OnScoreEvent += Scored;
        }

        private void EndGame()
        {
            
            GameState = GameState.GameOver;
        }
        private void Scored()
        {
            score++;
            if (OnScoreChanged != null) OnScoreChanged(score);
        }
    }

    public delegate void GameStateChangedEventHandler(GameState newGameState);
    public delegate void GameScoreChangedEventHandler(int newScore);

    public enum GameState
    {
        MainMenu, Playing, GameOver
    }

}