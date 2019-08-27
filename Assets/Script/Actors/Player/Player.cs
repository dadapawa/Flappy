using Script.Events;
using UnityEngine;
using Random = System.Random;

namespace Game
{
    [RequireComponent(typeof(FlapMover))]
    public class Player : MonoBehaviour
    {
        private const float targetMainMenuHeight = -0.5f;
        private PlayerDeathEventChannel playerDeathEventChannel;
        private GameController gameController;
        private FlapMover flapMover;
        private HazardSensor hazardSensor;
        private AudioSource deathSound;
        private void Awake() //Called when component is created (OnCeate)
        {
            gameController = Finder.GameController;
            flapMover = GetComponent<FlapMover>();
            hazardSensor = GetComponentInChildren<HazardSensor>();
            playerDeathEventChannel = Finder.PlayerDeathEventChannel;
            deathSound = GetComponent<AudioSource>();

        }

        private void Start()
        {
            //Called just before first frame where the component is used.
        }

        private void OnEnable()
        {
            //Called when component is activated (called before Start)
            hazardSensor.OnHit += OnHit;
        }

        private void OnDisable()
        {
            //Called when component is deactivated. Not called if initialy deactivated.
            hazardSensor.OnHit -= OnHit;
        }

        private void OnHit(GameObject objectThatHit)
        {
            Die();
        }

        //Permet l'appelle fonction directement dans l\editeur
        [ContextMenu("Die")]
        private void Die()
        {
            Destroy(gameObject);
            //GetComponent<AudioSource> ().Play ();
            deathSound.Play();
            Debug.Log("DEATHHHHHH!!!");
            playerDeathEventChannel.NotifyPlayerDeath();
            
        }
        
        private void Update()
        {
            
            var gameState = gameController.GameState;
            if (gameState == GameState.MainMenu)
            {
                if (transform.position.y < targetMainMenuHeight)
                {
                    flapMover.flap();
                }
            }
            else if (gameState == GameState.Playing)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    flapMover.flap();
                
            }
        }

        private void FixedUpdate()
        {
            //Called on fixed interval (when the physic engin is updating
        }

        private void OnDestroy()
        {
            //Called on the destruction of the component (Does not mean the gameobject is destroyed).
        }
    }
}