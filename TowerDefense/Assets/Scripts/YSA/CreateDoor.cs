using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{

    private float deltaTime = 1.0f;
    private float time;
    public GameObject enemy;
    private void Update()
    {
        if(Time.time > time + deltaTime)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            time = Time.time;
        }
    }
}
