using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Boss_deadState : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
}
