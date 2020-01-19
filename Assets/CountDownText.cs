using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    public float countDownStartSecond = 4;

    private float secLeft;

    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        secLeft = countDownStartSecond;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (secLeft >= 0)
        {
            secLeft -= Time.deltaTime;
            text.text = $"{(int) secLeft}";
        }
    }

    private void OnEnable()
    {
        secLeft = countDownStartSecond;
    }
}
