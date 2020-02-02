using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDataSource : MonoBehaviour
{
    public List<GameObject> brokenPieces = new List<GameObject>();

    public LiveStatus liveStatus
    {
        get => _liveStatus;
        set
        {
            _liveStatus = value;
            notifyObservers?.Invoke();
        }
    }
    private LiveStatus _liveStatus;
    private static int _lives = 3;

    public static int score
    {
        get => _score;
        set
        {
            _score = value;
            notifyObservers?.Invoke();
        }
    }
    private static int _score;

    public static int lives
    {
        get => _lives;

        set
        {
            _lives = value;
            notifyObservers?.Invoke();
        }
    }

    public static Action notifyObservers;
    

    
}

public enum LiveStatus
{
    ALIVE, DEAD
}