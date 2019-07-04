using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventForArrowTower : MonoBehaviour
{
    public GameObject movingArrowTower;
    private void OnMouseDown()
    {
        Instantiate(movingArrowTower, transform.position, Quaternion.identity);
    }
}
