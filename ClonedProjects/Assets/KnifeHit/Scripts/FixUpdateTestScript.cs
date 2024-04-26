using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixUpdateTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void Update()
    {
        ClickFunc();
    }

    void ClickFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("bastýn");
        }
    }
}
