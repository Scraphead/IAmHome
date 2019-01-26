using System;
// Maybe make this more ekspandable with more choices of event type to choose from? eksample adding EIngameStates too.

    [Serializable]
    public class GameEventReferencer
    {
        public bool useCustomGameEvent = true; //maybe use enums to split up the events
        public GameEvent gameEvent;
        public EGameState gameState;
        
        
        public GameEventReferencer() { }

    }

