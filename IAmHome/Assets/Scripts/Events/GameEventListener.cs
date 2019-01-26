using UnityEngine;
using UnityEngine.Events;
//**Reference the scriptableObject to a custom or any unity Events to raise the events**//

    //SHOULD MAKE THIS SO YOU CAN CHOICE BETWEEN SCRIPTABLE EVENTS AND FROM GAMENUMS EVENTS

    //Should also make a propertydrawer like the floatreference drawer so designer can select -
    //if they want to use enums or SO
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Choose your Event type to register with. Either with Custom event ScriptableObject or Prefixed event: EgameStates")]
        public GameEventReferencer eventType;
        
        //public GameEvent Event;
        //public EGameState gameState;
      
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

            if (eventType.gameState != EGameState.None)
            {
            //GameManager.Instance.RegisterToStateCallbacks(OnGameStateChanged);
        }
        }


        private void UnSubscribeToGameStateEvents()
        {
            if (eventType.useCustomGameEvent)
                return;

            if (eventType.gameState != EGameState.None)
            {
            //if (GameManager.Instance != null)
                //GameManager.Instance.UnregisterStateCallback(OnGameStateChanged);

        }

        }
       
    }
