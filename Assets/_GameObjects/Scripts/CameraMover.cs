using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMover : MonoBehaviour
{
    public Text text;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Camera.main.transform.eulerAngles.x.ToString();
        if (Camera.main.transform.eulerAngles.x < 360 && Camera.main.transform.eulerAngles.x > 180)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
