using Game;
using Script.Events;
using UnityEngine;

namespace Game
{
    public static class Finder
    {
        private const string GAME_CONTROLLER_TAG = "GameController";
        private static GameController gameController;
        private static PlayerDeathEventChannel playerDeathEventChannel;
        private static ScoreEventChannel scoreEventChannel;
        
        

        public static GameController GameController
        {
            get
            {
                if(gameController == null) //FindWithTag is slow, so we can use it as a singleton
                    gameController = GameObject.FindWithTag(GAME_CONTROLLER_TAG).GetComponent<GameController>();
                return gameController;
            }
        }    
        public static PlayerDeathEventChannel PlayerDeathEventChannel
        {
            get
            {
                if(playerDeathEventChannel == null) //FindWithTag is slow, so we can use it as a singleton
                    playerDeathEventChannel = GameObject.FindWithTag(GAME_CONTROLLER_TAG).GetComponent<PlayerDeathEventChannel>();
                return playerDeathEventChannel;
            }
        }    
        public static ScoreEventChannel ScoreEventChannel
        {
            get
            {
                if(scoreEventChannel == null) //FindWithTag is slow, so we can use it as a singleton
                    scoreEventChannel = GameObject.FindWithTag(GAME_CONTROLLER_TAG).GetComponent<ScoreEventChannel>();
                return scoreEventChannel;
            }
        }       
        
        
    }
}