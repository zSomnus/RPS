using TMPro;
using UnityEngine;

namespace Game.Scripts.MainMenu
{
    public class CountDownPanel : MonoBehaviour
    {
        public TextMeshProUGUI countDownText;

        private float countDownTime;



        private void OnEnable()
        {
            countDownTime = MainMenuManager.instance.countDownTime;

        }

        private void Update()
        {
            countDownTime -= Time.deltaTime;
            if (countDownTime >= 0)
            {
                countDownText.text = $"Countdown: {(int) countDownTime}";
            }
        }
    }
}
