using System;
using System.Collections;
using Script.Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [RequireComponent(typeof(TranslateMover))]
    public class Pipe : MonoBehaviour
    {
        private ScoreEventChannel scoreEventChannel;
        private TranslateMover mover;
        private GameController gameController;
        private bool pipeHasBeenPassed = false;
        private PlayerSensor playerSensor;
        [SerializeField] private float destroyDelay = 10f;
        [SerializeField] private float minY = -2f;
        [SerializeField] private float maxY = 0f;
        private void Awake() //Called when component is created (OnCeate)
        {
            gameController = Finder.GameController;
            mover = GetComponent<TranslateMover>();
            scoreEventChannel = Finder.ScoreEventChannel;
            playerSensor = GetComponentInChildren<PlayerSensor>();
        }

        private void Start()
        {
            transform.Translate(Vector3.up * Random.Range(minY,maxY));
            StartCoroutine(DestroyPipeRoutine());
            OnGameStageChanged(gameController.GameState);
        }

        private void OnEnable()
        {
            //playerSensor.OnHit += OnHit;
            //scoreEventChannel.OnScoreEvent += NotifyScore;
        }
        private void OnDisable()
        {
            //playerSensor.OnHit -= OnHit;
            //scoreEventChannel.OnScoreEvent -= NotifyScore;
        }

        private void Update()
        {
            if (gameController.GameState != GameState.MainMenu)
            {
                mover.move();
                if (transform.position.x < -0.5f && !pipeHasBeenPassed && gameController.GameState == GameState.Playing)
                {
                    if(transform.gameObject.name == "PipeBottom")
                        scoreEventChannel.NotifyPipePassed();
                    pipeHasBeenPassed = true;
                }
            }
        }

        public void OnGameStageChanged(GameState newGameState)
        {
            if (gameController.GameState != GameState.MainMenu)
            {
                mover.move();
            }
        }

        private void OnHit(GameObject gameObject)
        {
            //Increment score
        }
        
        private void NotifyScore()
        {
            //Increment score
        }
        
        
        private IEnumerator DestroyPipeRoutine()
        {
            yield return new WaitForSeconds(destroyDelay);
            Destroy(gameObject);
        }
    }
}