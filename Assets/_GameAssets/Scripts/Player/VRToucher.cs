using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRToucher : MonoBehaviour
{
    [SerializeField] Image targetImage;
    [SerializeField] float touchDistance;
    [SerializeField] float touchSpeed = 0.02f;
    private AudioSource audioSource;
    private RaycastHit hit;
    private bool pointing;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, touchDistance))
        {
            if (!pointing)
            {
                if (hit.collider.gameObject.CompareTag("Touchable") && !hit.collider.gameObject.GetComponent<TouchableAbstract>().isTouched)
                {
                    pointing = true;
                    StartCoroutine("Pointing");
                }
            }
        } else
        {
            pointing = false;
            targetImage.fillAmount = 0;
            StopCoroutine("Pointing");
        }
    }
    IEnumerator Pointing()
    {

        for (float i = 0; i <= 1; i = i + touchSpeed)
        {
            targetImage.fillAmount = i;
            yield return new WaitForSeconds(0.01f);
        }
        targetImage.fillAmount = 0;
        audioSource.Play();
        TouchObject();
    }
    private void TouchObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Touchable"))
            {
                hit.collider.gameObject.GetComponent<TouchableAbstract>().Touch();
            }
        }
    }
}
