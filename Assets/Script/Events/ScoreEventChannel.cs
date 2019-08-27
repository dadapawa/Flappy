using UnityEngine;

namespace Script.Events
{
    public class ScoreEventChannel : MonoBehaviour
    {
        public event ScoreEventHandler OnScoreEvent;
        
        public void NotifyPipePassed()
        {
            if (OnScoreEvent != null) OnScoreEvent();
        }

        public delegate void ScoreEventHandler();
    }
}