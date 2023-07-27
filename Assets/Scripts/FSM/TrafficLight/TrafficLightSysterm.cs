using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightSysterm : FSMSystem
{
    public RedState redState;
    public GreenState greenState;
    public YellowState yellowState;

    public Image imgLight;
    // Start is called before the first frame update
    void Awake()
    {
        redState.parent = this;
        AddState(redState);

        greenState.parent = this;
        AddState(greenState);

        yellowState.parent = this;
        AddState(yellowState);
    }

    public void OnGreenState()
    {
        GotoState(greenState, 60f);
    }
    public void OnRedState()
    {
        GotoState(redState, 60f);
    }
    public void OnReset()
    {
        GotoState(redState);
    }

}
