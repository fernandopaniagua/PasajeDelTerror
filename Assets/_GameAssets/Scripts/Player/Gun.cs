using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] float force;
    [SerializeField] float jumpSpeed;
    [SerializeField] float delay;
    private bool fireEnabled = true;
    void Update()
    {
        if (!GameManager.gameActive)
        {
            return;
        }
        if (fireEnabled && (Input.acceleration.y > jumpSpeed || Input.GetKeyDown(KeyCode.Space)))
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            fireEnabled = false;
            Invoke("EnableFire", delay);
        }
    }
    private void EnableFire()
    {
        fireEnabled = true;
    }
}
