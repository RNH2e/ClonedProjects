using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            if (!ATMRush.Instance.money.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger =false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                ATMRush.Instance.StackCube(other.gameObject, ATMRush.Instance.money.Count-1);
            }
        }
    }
}
