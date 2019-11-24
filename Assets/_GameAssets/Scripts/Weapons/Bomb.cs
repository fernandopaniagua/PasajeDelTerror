using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private bool collided = false;
    private const int TIME_TO_DESTROY = 3;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(this.gameObject, TIME_TO_DESTROY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collided)//Solo la primera vez
        {
            audioSource.Play();
            if (collision.transform.CompareTag("Zombi"))
            {
                collision.transform.GetComponent<Zombi>().Dead();
            }
        }
        collided = true;
    }
}
