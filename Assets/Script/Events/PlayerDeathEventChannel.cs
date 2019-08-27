using UnityEngine;

namespace Script.Events
{
    public class PlayerDeathEventChannel : MonoBehaviour
    {
        public event PlayerDeathEventHandler OnPlayerDeath;
        
        public void NotifyPlayerDeath()
        {
            
            Debug.Log("Notifying");
            if (OnPlayerDeath != null) OnPlayerDeath();
        }

        public delegate void PlayerDeathEventHandler();
    }
}