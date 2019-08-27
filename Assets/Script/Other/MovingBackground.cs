using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class MovingBackground : MonoBehaviour
    {

        [Header("Visual")]
        [SerializeField] private Sprite sprite = null;
        [Range(0,10)] [SerializeField] private uint nbFile = 3;
        [SerializeField] private string sortingLayerString = "Default";
        [Header("Behaviour")]
        [Range(0,100)] [SerializeField] private float speed = 1f;
        
        
        
        private Vector2 tileSize;
        private Vector3 initialPosition;
        private float offset;
        
        private void Awake() //Called when component is created (OnCeate)
        {
        }

        private void Start()
        {
            tileSize = sprite.bounds.size;
            for (int i = 0; i < nbFile; i++)
            {
                var tile = new GameObject(i.ToString());
                tile.transform.parent = transform; //Assign sont parent à celui-ci.
                tile.transform.localPosition = tileSize.x * i * Vector3.right;

                var spriteRenderer = tile.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;
                spriteRenderer.sortingLayerName = sortingLayerString;
            }
            //Called just before first frame where the component is used.
            //var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            //Debug.Assert(spriteRenderer != null, "No child Sprite");
            initialPosition = transform.position;
            offset = 0f;
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
            //All game object has a transform property
            offset = (offset + (speed * Time.deltaTime)) % tileSize.x;


            transform.position = initialPosition + Vector3.left * offset;
            //transform.Translate((Vector3.left*speed*Time.deltaTime));
            //if (transform.position.x <= posXWhenPassed)
            //{
            //    var position = transform.position;
            //    position.x = (float)0.48;
            //    transform.position = position;
            //}
        }

        private void FixedUpdate()
        {
            //Called on fixed interval (when the physic engin is updating
        }

        private void OnDestroy()
        {
            //Called on the destruction of the component (Does not mean the gameobject is destroyed).
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            var size = sprite == null? Vector3.one : sprite.bounds.size;
            var center = transform.position;

            //Dessinage dans l'editeur
            Gizmos.DrawWireCube(center, size);
        }
#endif
    }
}