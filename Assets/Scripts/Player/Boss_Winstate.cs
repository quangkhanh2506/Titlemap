using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class Boss_Winstate : FSMState
{
    [NonSerialized]
    public BossSysterm parent;
}
