using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomBehaviour : MonoBehaviour
{
    public abstract void Action(EnemyTank tank, AIDetector detector);

}
