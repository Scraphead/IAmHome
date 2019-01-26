using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum EGameState
{
    None,
    Reset_Game,
    Game_Started,
    Game_Over
}
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get => _instance; set => _instance = value; }

    public Action<EGameState> OnGameStateChangedCallback { get; set; }
    private EGameState curentGameState;
    public bool haveKey = false;
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
      
    }
    private void Start()
    {
        curentGameState = EGameState.Game_Started;
        if (OnGameStateChangedCallback != null)
            OnGameStateChangedCallback(curentGameState);
    }
    public void OnGamestateChanged(EGameState gameState)
    {
        switch (gameState)
        {
            case EGameState.Game_Started:
                haveKey = false;
                break;

            case EGameState.Game_Over:

                break;
        }
    }

    public void GameFinnished()
    {
        curentGameState = EGameState.Game_Over;
        if (OnGameStateChangedCallback != null)
            OnGameStateChangedCallback(curentGameState);
    }


}
