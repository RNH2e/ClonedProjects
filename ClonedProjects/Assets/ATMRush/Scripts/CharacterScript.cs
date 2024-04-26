
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float swipeSpeed = 5;
    public float moveSpeed = 5;
    public Mesh cube;
    public Material mat;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;


        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(mousePos, transform.forward * hit.distance, Color.red);
            GameObject firstObj = ATMRush.Instance.money[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstObj.transform.localPosition.y;
            hitVec.z = firstObj.transform.localPosition.z;
            firstObj.transform.localPosition = Vector3.MoveTowards(firstObj.transform.localPosition, -hitVec, Time.deltaTime * swipeSpeed);
        }
    }
}
