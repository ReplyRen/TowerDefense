using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject[] Army;
    private void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Army = GameObject.FindGameObjectsWithTag("Army");
    }
}
