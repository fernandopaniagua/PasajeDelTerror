using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    private const string PARAM_WALKING = "Walking";
    private const string PARAM_ATTACKING = "Attacking";

    private GameObject vrPlayer;
    private Animator animator;
    public float distanceToWalk;
    public float distanceToAttack;
    public float distanceToDamage;
    public float speed;
    public float damage;
    
    void Start()
    {
        vrPlayer = GameObject.Find("VRPlayer");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (HasDistanceToWalk())
        {
            if (!HasDistanceToAttack())
            {
                animator.SetBool(PARAM_WALKING, true);
                LookAtPlayer();
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        } else
        {
            animator.SetBool(PARAM_WALKING, false);
        }

        if (HasDistanceToAttack())
        {
            animator.SetBool(PARAM_ATTACKING, true);
            LookAtPlayer();
        }
        else
        {
            animator.SetBool(PARAM_ATTACKING, false);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 target = new Vector3(vrPlayer.transform.position.x, transform.position.y, vrPlayer.transform.position.z);
        transform.LookAt(target);
    }

    private bool HasDistanceToWalk()
    {
        return Vector3.Distance(transform.position, vrPlayer.transform.position) < distanceToWalk;
    }

    private bool HasDistanceToAttack()
    {
        return Vector3.Distance(transform.position, vrPlayer.transform.position) < distanceToAttack;
    }

    private void Attack()
    {
        //Triggered by Animation
        if (Vector3.Distance(transform.position, vrPlayer.transform.position)< distanceToDamage)
        {
            vrPlayer.GetComponent<PlayerVR>().DoDamage(damage);
        }
    }
}
