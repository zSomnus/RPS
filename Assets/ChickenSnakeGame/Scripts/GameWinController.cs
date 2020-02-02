using System;
using ChickenSnakeGame.Scripts;
using Game.Scripts;
using UnityEngine;

public class GameWinController: MonoBehaviour
{
    [SerializeField] private SpawnerParameter spawnerParameter;
    [SerializeField] private SnakeDataSource snakeDataSource;

    public static GameWinController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        SnakeDataSource.notifyObservers += Judicate;
        spawnerParameter.notifyObservers += Judicate;
    }

    private void Judicate()
    {
        if (SnakeDataSource.score == GameParameter.instance.scoreRequired)
        {
            AirConsoleController.instance.miniGameOutputData = new MiniGameOutputData(AirConsoleController.players[GameParameter.instance.defenderPlayerIndex-1], (int)(GameParameter.instance.healthDealtToPlayer/GameParameter.instance.defenseSuccessDamageModifier));
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadMainGame();
        }

        if (SnakeDataSource.lives <= 0)
        {
            AirConsoleController.instance.miniGameOutputData = new MiniGameOutputData(AirConsoleController.players[GameParameter.instance.defenderPlayerIndex-1], GameParameter.instance.healthDealtToPlayer);
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadMainGame();
        }
        
        
        
    }
}