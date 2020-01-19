namespace Game.Scripts.DataClass
{
    public class PlayerInfo
    {
        /// <summary>
        /// 1 means index is Player 1,
        /// 2 means index is Player 2
        /// </summary>
        public int index { get; set; }
        
        /// <summary>
        /// What the controller device index that controls this player
        /// </summary>
        public int deviceId { get; set; }

        /// <summary>
        /// Is the player ready to get into the main game
        /// </summary>
        public bool ready { get; set; }

        public int Score { get; set; }

        public HandGesture handGesture { get; set; } = HandGesture.Pending;

        public PlayerInfo(int deviceId, int index)
        {
            this.deviceId = deviceId;
            this.index = index;
        }
            
            
    }
    
    public enum HandGesture{Pending ,Paper, Rock, Scissors}
}