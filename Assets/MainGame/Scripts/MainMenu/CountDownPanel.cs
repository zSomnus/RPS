using System;
using System.Collections;
using System.Collections.Generic;
using MainGame.Scripts.MainMenu;
using TMPro;
using UnityEngine;

public class CountDownPanel : MonoBehaviour
{
    public TextMeshProUGUI countDownText;

    private float countDownTime;

    private void Start()
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
