using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates { countDown, running, receOver};

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    GameStates gameStates = GameStates.countDown;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void LevelStart()
    {
        gameStates = GameStates.countDown;

        Debug.Log("Level Started");
    }
    
  public  GameStates GetGameStates()
    {
        return gameStates;
    }

    public void OnRaceStart()
    {
        Debug.Log("OnRaceStart");

        gameStates = GameStates.running;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        throw new System.NotImplementedException();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelStart();
    }

   
}
