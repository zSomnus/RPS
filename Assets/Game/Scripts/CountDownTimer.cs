using UnityEngine;

namespace Game.Scripts
{
    public class CountDownTimer : MonoBehaviour
    {

        public static CountDownTimer instance;
        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
