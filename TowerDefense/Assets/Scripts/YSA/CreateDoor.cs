using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDoor : MonoBehaviour
{

    private float deltaTime = 1.0f;
    private float time;
    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public List<float> nextFireTime = new List<float>();   // 每个敌人所对应的被攻击的间隔时间

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
    private void Update()
    {
        if(Time.time > time + deltaTime)
        {
            GameObject go =  Instantiate(enemy, transform.position, Quaternion.identity);
            enemies.Add(go);
            nextFireTime.Add(0);
            time = Time.time;
        }
    }
}
