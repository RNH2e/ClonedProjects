using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateCylinderScript : MonoBehaviour
{
    public float rotateSpeed;
    public float moveX;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Mouse X");

       
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // text.gameObject.SetActive(false);
            transform.Rotate(0, moveX * Time.fixedDeltaTime*100* rotateSpeed, 0);
        }
    }
}
