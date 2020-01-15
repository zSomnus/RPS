namespace RockPaperScissor
{
    public class PlayerInfo
    {

        public int index { get; set; }
        public int deviceId { get; set; }

        public bool ready { get; set; }

        public PlayerInfo(int deviceId, int index)
        {
            this.deviceId = deviceId;
            this.index = index;
        }
            
            
    }
}