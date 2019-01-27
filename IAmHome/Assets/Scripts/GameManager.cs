using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
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
    public bool openedDoor = false;
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
                openedDoor = false;
                break;

            case EGameState.Game_Over:

                break;
            case EGameState.Reset_Game:
                curentGameState = EGameState.Game_Started;

                if (OnGameStateChangedCallback != null)
                    OnGameStateChangedCallback(curentGameState);
                break;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }
    public void RestartGame()
    {
        curentGameState = EGameState.Reset_Game;
        if (OnGameStateChangedCallback != null)
            OnGameStateChangedCallback(curentGameState);
        SceneManager.LoadScene(0);
    }
    public void GameFinnishhed()
    {
        if (haveKey && openedDoor)
        {
            curentGameState = EGameState.Game_Over;
            if (OnGameStateChangedCallback != null)
                OnGameStateChangedCallback(curentGameState);
        }
       
    }


}
