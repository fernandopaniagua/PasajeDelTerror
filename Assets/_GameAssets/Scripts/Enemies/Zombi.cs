using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    private const string PARAM_WALKING = "Walking";
    private const string PARAM_ATTACKING = "Attacking";
    private const string PARAM_IS_DEAD = "IsDead";

    private GameObject vrPlayer;
    private Animator animator;
    private bool alive = true;//Indica si el asqueroso del zombi está vivo
    public float distanceToWalk;
    public float distanceToAttack;
    public float distanceToDamage;
    public float speed;
    public float damage;
    public AudioClip[] inhaleAudioClips;
    public AudioClip[] attackAudioClips;
    private AudioSource audioSource;

    void Start()
    {
        vrPlayer = GameObject.Find("VRPlayer");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!GameManager.gameActive || !alive)//Si el juego no se ha arrancado o el zombie esta ko, salimos del update
        {
            return;
        }
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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(attackAudioClips[Random.Range(0, attackAudioClips.Length)]);
            }
        }
        else
        {
            animator.SetBool(PARAM_ATTACKING, false);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(inhaleAudioClips[Random.Range(0, inhaleAudioClips.Length)]);
            }
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

    public void Dead()
    {
        animator.SetBool(PARAM_IS_DEAD, true);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        alive = false;
    }
}
