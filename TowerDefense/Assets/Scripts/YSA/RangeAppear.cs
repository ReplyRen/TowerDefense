using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAppear : MonoBehaviour
{
    private float size;
    void Update()
    {
        if(gameObject.name == "ArrowTower(Clone)")
        {
            size = gameObject.GetComponent<ArrowTower>().attackRange * 4 / 3;
        }
        else if(gameObject.name == "SwordTower(Clone)")
        {
            size = gameObject.GetComponent<SwordTower>().attackRange * 4 / 3;
        }
        float dis = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10.0f), gameObject.transform.position);
        if (dis < 0.5f)
        {
            GameObject go = gameObject.transform.Find("Tower_child").gameObject.transform.Find("Circle").gameObject;
            go.SetActive(true);
            go.transform.localScale = new Vector3(size, size, size);
        }
        else
        {
            gameObject.transform.Find("Tower_child").gameObject.transform.Find("Circle").gameObject.SetActive(false);
        }
    }
}
