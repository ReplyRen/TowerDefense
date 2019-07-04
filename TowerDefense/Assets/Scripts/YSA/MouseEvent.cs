using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject towerBase;
    private bool ifMakeBase = true;
    private void OnMouseDown()
    {
        if (ifMakeBase)
        {
            Instantiate(towerBase, transform.position + new Vector3(-0.4f, -0.2f, 0), Quaternion.identity);
            ifMakeBase = false;
        }
       
    }
}
