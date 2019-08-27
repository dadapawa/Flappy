using UnityEngine;

namespace Game
{
    public class HazardSensor : MonoBehaviour
    {
        public event SensorEventHandler OnHit;
        
        
        //private void OnCollisionEnter2D(Collision2D other)
        //{
        //    //other = other object that collide with
        //    var stimuli = other.gameObject.GetComponent<Stimuli>();
        //    if (stimuli != null)
        //    {
        //        Debug.Log("Collision with " + other.gameObject.name);
        //        stimuli.Hit(this);
        //    }
        //}   
        private void OnTriggerEnter2D(Collider2D other)
        {
            //other = other object that collide with
            var sensor = other.gameObject.GetComponent<HazardSensor>();
            if (sensor != null)
            {
                Debug.Log("Collision with " + other.gameObject.name);

                var parent = other.transform.parent; //Parent
                var gameobject = parent != null ? parent.gameObject : other.gameObject; //if parent = null, return other.gO
                if (OnHit != null) OnHit(gameobject); 
                //stimuli.Hit(this);
            }
        }   
        
        private void Awake()
        {
        }

        public delegate void SensorEventHandler(GameObject other);
    }
}