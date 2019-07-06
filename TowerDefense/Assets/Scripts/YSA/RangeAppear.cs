using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAppear : MonoBehaviour
{
    void Update()
    {
        float dis = Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10.0f), gameObject.transform.position);
        if (dis < 0.5f)
        {
            gameObject.transform.Find("Circle").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.Find("Circle").gameObject.SetActive(false);
        }
    }
}
