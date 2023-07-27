using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{
    private List<FSMState> lsStates = new List<FSMState>();
    public FSMState curState;

    public void AddState(FSMState state)
    {
        lsStates.Add(state);

        if (lsStates.Count == 1)
        {
            curState = state;
            curState.OnEnter();
        }
    }

    public void GotoState(FSMState state)
    {
        if (curState != null)
        {
            curState.OnExit();
        }

        curState = state;
        curState.OnEnter();
    }

    public void GotoState(FSMState state, object data)
    {
        if (curState != null)
        {
            curState.OnExit();
        }

        curState = state;
        curState.OnEnter(data);
    }

    public virtual void OnSystemStart()
    {

    }

    public virtual void OnSystemFixedUpdate()
    {

    }

    public virtual void OnSystemUpdate()
    {

    }

    public virtual void OnSystemLateUpdate()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        OnSystemStart();
    }

    // Update is called once per frame
    void Update()
    {
        OnSystemUpdate();
        if (curState != null)
        {
            curState.OnUpdate();
        }
    }

    private void FixedUpdate()
    {
        OnSystemFixedUpdate();
        if (curState != null)
        {
            curState.OnFixedUpdate();
        }
    }

    private void LateUpdate()
    {
        OnSystemLateUpdate();
        if (curState != null)
        {
            curState.OnLateUpdate();
        }
    }

    public virtual void OnSetup()
    {

    }
}
