using UnityEngine;

namespace Game.Prefabs.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
    public class Card : ScriptableObject
    {
        
        public new string name;
        
        public string description;

        [Tooltip("The artwork of the front of the card")] 
        public Sprite cardFront;

        [Tooltip("The artwork of the back of the card")]
        public Sprite cardBack;
        
        [Tooltip("The icon of the character of this card")]
        public Sprite characterImage;
        
        [Tooltip("Who can the card wins")]
        public Sprite strength;
        
        [Tooltip("Who will the card get beaten by")]
        public Sprite weakness;
        
    }
}
