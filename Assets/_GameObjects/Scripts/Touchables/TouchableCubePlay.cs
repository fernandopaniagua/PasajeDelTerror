using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchableCubePlay : TouchableAbstract
{
    public override void Touch()
    {
        GameManager.gameActive = true;
        gameObject.SetActive(false);
    }

}
