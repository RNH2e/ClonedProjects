using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Vector3 startPos;
    float lerpValue;
    int distance = 1;
    public Vector3 newpos = new Vector3(12,0,0);
    public bool single;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (single)
        {
            transform.position = Vector3.Lerp(startPos, startPos + newpos, lerpValue);
            lerpValue += distance * Time.deltaTime;

            if (lerpValue >= 1 && distance == 1)
            {
                distance = -1;
            }
            if (lerpValue <= 0 && distance == -1)
            {
                distance = 1;
            }
        }
   
    }
}
