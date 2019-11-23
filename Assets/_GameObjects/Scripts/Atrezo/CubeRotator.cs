using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Rotate(speed, speed, speed);    
    }
}
