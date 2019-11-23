using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableCofre : TouchableAbstract
{
    public override void Touch()
    {
        GetComponent<Animator>().SetBool("Open", true);
    }
}
