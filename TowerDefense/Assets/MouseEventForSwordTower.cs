using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventForSwordTower : MonoBehaviour
{
    public GameObject movingSwordTower;
    private void OnMouseDown()
    {
        Instantiate(movingSwordTower, transform.position, Quaternion.identity);
    }
}
