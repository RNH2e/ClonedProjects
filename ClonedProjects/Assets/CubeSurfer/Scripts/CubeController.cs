using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public DummyScript characterScript;
    public Vector3 direction = Vector3.back;
    bool isStack = false;

    // Start is called before the first frame update
    void Start()
    {
        characterScript = GameObject.FindAnyObjectByType<DummyScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        RaycastHit hit;
      //  Debug.DrawRay(transform.position, Vector3.back * 2, Color.red);
        if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), Vector3.back * 2, out hit, Quaternion.identity, 1)
            || Physics.BoxCast(transform.position, new Vector3(1, 1, 1), Vector3.right, out hit, Quaternion.identity, 1)
            || Physics.BoxCast(transform.position, new Vector3(1, 1, 1), Vector3.left, out hit, Quaternion.identity, 1))
        {
            Debug.Log("1");
            if (!isStack)
            {
                isStack = true;
                characterScript.IncreaseBlockStack(gameObject);
                SetDirection();
            }
        }
        Debug.DrawRay(transform.position + Vector3.up , Vector3.forward * 2, Color.green);

        if (Physics.Raycast(transform.position + Vector3.up,  Vector3.forward * 2, out hit,  1,1<<6))
        {
            Debug.Log("obss");
            characterScript.DecreaseBlock(gameObject);

        }
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward * 2, out hit, 1, 1 << 7))
        {
            characterScript.isFinish = true;
            characterScript.DecreaseBlock(gameObject);

        }

    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}


