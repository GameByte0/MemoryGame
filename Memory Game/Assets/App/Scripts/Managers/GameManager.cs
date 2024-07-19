using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }

    private int _difficultyLevel = 0;
    private int _gameMode = 0;
    public int DifficultyLevel { get => _difficultyLevel;  }
    public int GameMode { get => _gameMode; }

    private void Start()
    {
        Singletone();
        DontDestroyOnLoad(this);
        
    }
    private void Singletone()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
    }

    public void SetGameSettings(int difficulty,int gameMode)
    {
        _difficultyLevel = difficulty;
        _gameMode = gameMode;
    }
}
public enum DifficultyLevel
{
    EASY,
    NORMAL,
    HARD
}
public enum GameMode
{
    CLASSIC,
    BLACKOUT
}
