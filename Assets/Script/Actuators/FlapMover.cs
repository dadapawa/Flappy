using UnityEngine;

namespace Game
{
    public class FlapMover : MonoBehaviour
    {
        
        [SerializeField] private Vector2 flapForce = Vector2.up * 5;
        private Rigidbody2D rigidBody2D;
        private void Awake() //Called when component is created (OnCeate)
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
        }
        
        
        public void flap()
        {
            rigidBody2D.velocity = flapForce;
        }

    }
}