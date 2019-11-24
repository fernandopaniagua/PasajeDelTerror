using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableCofre : TouchableAbstract
{
    public override void Touch()
    {
        if (!isTouched)
        {
            GetComponent<Animator>().SetBool("Open", true);
            GetComponent<BoxCollider>().enabled = false;
            isTouched = true;
        }
    }
}
