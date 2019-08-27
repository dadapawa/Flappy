using UnityEngine;

namespace Game
{
    public class TranslateMover : MonoBehaviour
    {
        [SerializeField] private Vector3 velocity = Vector3.left;


        public void move()
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}