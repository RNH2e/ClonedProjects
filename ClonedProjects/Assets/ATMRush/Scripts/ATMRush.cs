using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ATMRush : MonoBehaviour
{
    public static ATMRush Instance;
    public List<GameObject> money = new List<GameObject>();
    public float movementDelay = .25f;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackCube(GameObject other, int idx) 
    {
        other.transform.parent = transform;
        Vector3 newPos = money[idx].transform.localPosition;
        newPos.z -= 1;
        other.transform.localPosition = newPos;
        StartCoroutine(MakeObjectBigger());
        money.Add(other);
        GetComponentInChildren<Animator>().SetTrigger("catch");
    }

    private IEnumerator MakeObjectBigger()
    {
        for (int i = money.Count-1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1,1,1);
            scale *= 1.5f;
            money[index].transform.DOScale(scale, .1f).OnComplete(() =>
            money[index].transform.DOScale(new Vector3(1, 1, 1), .1f));
            yield return new WaitForSeconds(.05f);
                
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i < money.Count; i++)
        {
            Vector3 pos = money[i].transform.localPosition;
            pos.x = money[i - 1].transform.localPosition.x;
            money[i].transform.DOLocalMove(pos,movementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < money.Count; i++)
        {
            Vector3 pos = money[i].transform.localPosition;
            pos.x = money[0].transform.localPosition.x;
            money[i].transform.DOLocalMove(pos, .7f);
        }
    }
}
