using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    private Rigidbody rb;

 
 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sphere")
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("knife is in the sphere");
            transform.SetParent(other.gameObject.transform);
            rb.velocity = Vector3.zero;
            transform.tag = "Dead";
            GetComponent<KnifeScript>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = true;
            GameManager.Instance.MakeKnifesImageBlack();
            GameManager.Instance.canShoot = true;
        }
        if (other.CompareTag("Dead"))
        {
            Debug.Log("game over");
        }
    }



}
