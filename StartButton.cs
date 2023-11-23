using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public TimeCounter timeCounter;

    void Start()
    {
        // Assuming the button is on the same GameObject as this script
        Button button = GetComponent<Button>();

        // Attach the method to the button's click event
        button.onClick.AddListener(OnStartButtonClick);
    }

    public void OnStartButtonClick()
    {
        timeCounter.StartTimer();
    }
}