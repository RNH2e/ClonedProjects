using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        string matName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        GameObject splash = Instantiate(splashPrefab, transform.position + new Vector3(0, -0.2f, 0), transform.rotation);
        splash.transform.SetParent(collision.gameObject.transform);
        rb.AddForce(Vector3.up * jumpForce);
        if (collision.gameObject.CompareTag("Optimization"))
        {
            Debug.Log("finish");
            //SceneManager.LoadScene(0);
        }
        if (matName == "Break (Instance)")
        {
            Debug.Log(matName);
            collision.gameObject.SetActive(false);
        }
        else if (matName == "Block (Instance)")
        {

        }
    }
}
