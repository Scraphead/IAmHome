using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    None,
    Menu,
    Loading_Game,
    Loaded_Game,
    Reset_Game,
    Game_Started,
    Game_Over
}

    //SHOULD MAKE THIS SO YOU CAN CHOICE BETWEEN SCRIPTABLE EVENTS AND FROM GAMENUMS EVENTS
   
    //Should also make a propertydrawer like the floatreference drawer so designer can select -
    //if they want to use enums or SO
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        #if UNITY_EDITOR
           [Multiline]
           public string DeveloperDescription = "";
        #endif

        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> _eventListeners = 
            new List<GameEventListener>();

        public void RaiseEvents()
        {
            for(int i = _eventListeners.Count -1; i >= 0; i--)
                _eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
