using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public class Foreground: MonoBehaviour
    {

        [SerializeField] private double posXWhenPassed = -10.653;
        private void Awake() //Called when component is created (OnCeate)
        {
        }

        private void Start()
        {
            //Called just before first frame where the component is used.
        }

        private void OnEnable()
        {
            //Called when component is activated (called before Start)
        }

        private void OnDisable()
        {
            //Called when component is deactivated. Not called if initialy deactivated.
        }

        private void Update()
        {
            //Called on each frame. Should always be light code
            
            //All game object has a transform property
            transform.Translate((Vector3.left*5*Time.deltaTime));
            if (transform.position.x <= posXWhenPassed)
            {
                var position = transform.position;
                position.x = (float)0.86;
                transform.position = position;
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