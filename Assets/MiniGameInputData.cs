using Game.Scripts.DataClass;

public class MiniGameInputData
{
    public PlayerInfo attackPlayer { get; set; }
    public PlayerInfo defensePlayer { get; set; }

    public MiniGameInputData(PlayerInfo attackPlayer, PlayerInfo defensePlayer)
    {
        this.attackPlayer = attackPlayer;
        this.defensePlayer = defensePlayer;
    }
}