using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{

    private float deltaTime = 1.0f;
    private float time;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public List<GameObject> enemies = new List<GameObject>();
    public List<float> nextFireTime = new List<float>();   // 每个敌人所对应的被攻击的间隔时间
    private GameObject go;

    private static CreateDoor _instance;
    public static CreateDoor instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private int i = 0;
    private void Update()
    {
        if(i < 15)
        {
            deltaTime = 5.0f;
        }
        else if(i < 40)
        {
            deltaTime = 2.0f;
        }

        else if(i < 150)
        {
            deltaTime = 1.0f;
        }

         
        if (Time.time > time + deltaTime)
        {
            if(i < 15)
            {
               go = Instantiate(enemy1, transform.position, Quaternion.identity);
            }
            else if(i % 4 == 0)
            {
                go = Instantiate(enemy2, transform.position, Quaternion.identity);
            }
            else if(i > 70 && i % 7 == 0)
            {
                go = Instantiate(enemy3, transform.position, Quaternion.identity);
            }
            else
            {
                go = Instantiate(enemy1, transform.position, Quaternion.identity);
            }
            i++;
            enemies.Add(go);
            nextFireTime.Add(0);
            time = Time.time;
        }
    }
}
