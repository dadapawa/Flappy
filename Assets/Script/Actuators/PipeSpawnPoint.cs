using System.Collections;
using UnityEngine;

namespace Game
{
    public class PipeSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;

        private GameController gameController;

        private void Awake()
        {
            gameController = Finder.GameController;
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnPipeRoutine());
        }

        private IEnumerator SpawnPipeRoutine()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(2);
                if(gameController.GameState != GameState.MainMenu)
                    Instantiate(pipePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}