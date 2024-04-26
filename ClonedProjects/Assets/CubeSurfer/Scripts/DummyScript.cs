using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimitValue;
    [SerializeField] private float horizotalValue;
    private float newPosX;

    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlock;
    public bool isFinish, isFail;
    public GameObject ps;


    private void Start()
    {
        UpdateLastBlock();
    }
    public void FixedUpdate()
    {
        SetForwardMovement();
        SetHorizontalMovement();
    }

    void Update()
    {

        HandleHeroHorizontalInput();
    }
    public float HorizantalValue
    {
        get { return horizotalValue; }
    }

    private void HandleHeroHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizotalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizotalValue = 0;
        }
    }
    private void SetForwardMovement()
    {

            transform.Translate(Vector3.forward * forwardSpeed * Time.fixedDeltaTime);

        
    }
    private void SetHorizontalMovement()
    {
        newPosX = transform.position.x + HorizantalValue * horizontalSpeed * Time.fixedDeltaTime;
        newPosX = Mathf.Clamp(newPosX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }

    public void IncreaseBlockStack(GameObject _gameObject)
    {
        GetComponent<AudioSource>().Play();
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlock.transform.position.x, lastBlock.transform.position.y - 2f, transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlock();
    }
    public void DecreaseBlock(GameObject _gameObject)
    {

        if ((blockList.Count <= 1 || blockList == null) && !isFinish)
        {
            Debug.Log("GameOver");
            UIManager.Instance.CheckFail(5);
            GetComponentInChildren<Animator>().SetTrigger("fail");
            if (!isFail)
            {
                isFail = true;
                GetComponent<Rigidbody>().AddForce(Vector3.back * 2000);
            }
        }
        else if ((blockList.Count <= 1 || blockList == null) && isFinish)
        {
            transform.Translate(0, 0, 0);
            Debug.Log("Succes");
            ps.GetComponent<ParticleSystem>().Play();
            GetComponentInChildren<Animator>().SetTrigger("succes");
            UIManager.Instance.CheckSucces(5);
        }
        else
        {
            _gameObject.transform.parent = null;
            blockList.Remove(_gameObject);
            UpdateLastBlock();

        }
    }


    private void UpdateLastBlock()
    {
        lastBlock = blockList[blockList.Count - 1];
    }
}
