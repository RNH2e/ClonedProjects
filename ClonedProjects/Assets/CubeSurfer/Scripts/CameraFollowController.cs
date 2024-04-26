using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;
    private Vector3 newPos;
    private Vector3 offset;
    [SerializeField] private float lerpValue;
    public float rotationSpeed = 2.0f;

    private void Start()
    {
        offset = transform.position - characterTransform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Break();
        }
    }
    void LateUpdate()
    {
        SetCameraSmoothFollow();
        SmoothRotateTowards(characterTransform.position);
    }
    private void SmoothRotateTowards(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = newRotation;
    }
    private void SetCameraSmoothFollow() 
    {
        newPos = Vector3.Lerp(transform.position, new Vector3(0,characterTransform.transform.position.y, characterTransform.transform.position.z) + offset, lerpValue*Time.deltaTime);
        transform.position = newPos;
    } 
}
