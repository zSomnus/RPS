using Game.Scripts.DataClass;

public class MiniGameOutputData
{
    public PlayerInfo playerReceiveDamage { get; set; }
    public int damage { get; set; }

    public MiniGameOutputData(PlayerInfo playerReceiveDamage, int damage)
    {
        this.playerReceiveDamage = playerReceiveDamage;
        this.damage = damage;
    }
}