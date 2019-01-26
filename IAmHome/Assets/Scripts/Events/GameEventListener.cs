using UnityEngine;
using UnityEngine.Events;
//**Reference the scriptableObject to a custom or any unity Events to raise the events**//

    
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Choose your Event type to register with. Either with Custom event ScriptableObject or Prefixed event: EgameStates")]
        public GameEventReferencer eventType;
        
       
      
        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;
        
      
        private void OnEnable()
        {
            SubscribeToGameStateEvents();
            if(eventType.useCustomGameEvent)
                eventType.gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (eventType.useCustomGameEvent)
                eventType.gameEvent.UnregisterListener(this);

            UnSubscribeToGameStateEvents();
        }

        public void OnEventRaised()
        {
            if (eventType.useCustomGameEvent)
            {
                Response.Invoke();
                //Debug.Log("Invoked UnityEvent Responses using Custom ScriptableObject GameEvent. SO EventName: " + eventType.gameEvent);

            }

        }

        void OnGameStateChanged(EGameState gameStates)
        {
            if (gameStates == eventType.gameState)
            {
                Response.Invoke();
                //Debug.Log("Invoked UnityEvent Responses using EGameState. GameState Name: " + gameStates);
            }

        }

        private void SubscribeToGameStateEvents()
        {
            if (eventType.useCustomGameEvent)
                return;

        GameManager.Instance.OnGameStateChangedCallback += OnGameStateChanged;
          
        }


        private void UnSubscribeToGameStateEvents()
        {
            if (eventType.useCustomGameEvent)
                return;

        GameManager.Instance.OnGameStateChangedCallback -= OnGameStateChanged;


    }

}
