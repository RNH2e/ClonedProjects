using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public KnifeScript[] knifes;
    [SerializeField] private float speed;
    public int shootCount;

    public GameObject knifeImage, knifeImagePos, knifeImageParent;
    public GameObject knife;

    public int knifeCount;
    public bool canShoot = true;
    public bool click = false;

    [SerializeField] private GameObject knifesImage;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < knifeCount -1 ; i++)
        {
            Instantiate(knife, knife.transform.position, knife.transform.rotation);
        }
        for (int i = 0; i < knifeCount ; i++)
        {
            GameObject g = Instantiate(knifeImage, new Vector3(-2, knifeImagePos.transform.position.y-.5f, 0), Quaternion.identity,knifeImageParent.transform);
            knifeImagePos = g;
            
        }
        knifes = FindObjectsOfType<KnifeScript>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            click = false;
        }
    }

    private void FixedUpdate()
    {
        if (click && canShoot)
        {
            shootCount++;
            if (shootCount < knifes.Length + 1)
            {
                knifes[shootCount - 1].GetComponent<Rigidbody>().velocity = Vector3.up * speed * Time.deltaTime;
                knifes[shootCount - 1].GetComponent<BoxCollider>().enabled = true;
                Debug.LogFormat("<color=red> shootCount: </color>" + shootCount);
            }
            canShoot = false;

        }
    }

    public void MakeKnifesImageBlack()
    {
     
        if (shootCount < knifesImage.transform.childCount + 1)
        {
            Debug.Log("buraya girdi");
            knifesImage.transform.GetChild(shootCount - 1).transform.GetComponent<SpriteRenderer>().color = Color.black;
        }

    }
}
