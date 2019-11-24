using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchableKey : TouchableAbstract
{
    public Transform inventory;
    public Sprite spriteKey;
    public override void Touch()
    {
        if (!isTouched)
        {
            inventory.GetComponent<Image>().enabled = true;
            inventory.GetComponent<Image>().sprite = spriteKey;
            isTouched = true;
            Destroy(gameObject);
        }
    }
}
