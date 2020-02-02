using Game.Scripts.DataClass;

public class MiniGameInputData
{
    public PlayerInfo attackPlayer { get; set; }
    public PlayerInfo defensePlayer { get; set; }

    public int miniGameSceneIndex;
    
    public MiniGameInputData(PlayerInfo attackPlayer, PlayerInfo defensePlayer, int miniGameSceneIndex)
    {
        this.attackPlayer = attackPlayer;
        this.defensePlayer = defensePlayer;
        this.miniGameSceneIndex = miniGameSceneIndex;
    }
}