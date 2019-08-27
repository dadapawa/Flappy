using UnityEngine;

namespace Game
{
    public class PlayerSensor : MonoBehaviour
    {
        public event SensorEventHandler OnHit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            //other = other object that collide with
            var stimuli = other.gameObject.GetComponent<PlayerStimuli>();
            if (stimuli != null)
            {
                Debug.Log("Collision with " + other.gameObject.name);

                var parent = other.transform.parent; //Parent
                var gameobject = parent != null ? parent.gameObject : other.gameObject; //if parent = null, return other.gO
                if (OnHit != null) OnHit(gameobject); 
                //stimuli.Hit(this);
            }
        }   

        public delegate void SensorEventHandler(GameObject other);
    }
}