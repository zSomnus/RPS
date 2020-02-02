using System;
using UnityEngine;

public class SpawnerParameter: MonoBehaviour
{
    public Action notifyObservers;
    
    private int _spawnCount;
    
    public int spawnCount
    {
        get => _spawnCount;

        set
        {
            _spawnCount = value;
            notifyObservers?.Invoke();
        }
    }
}