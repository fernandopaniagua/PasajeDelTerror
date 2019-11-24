using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TouchableAbstract : MonoBehaviour
{
    public bool isTouched = false;
    public abstract void Touch();
}
