using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
