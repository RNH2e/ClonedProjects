using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerScript : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, offset + ball.transform.position, smoothSpeed);
        transform.position = newPos;
    }
}
