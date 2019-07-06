using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    // Start is called before the first frame update
    public int index = 0;                //敌人编号
    public GameObject arrow;             //箭
    private bool ifAttack = false;       //判断是否攻击
    private float nextFire = 0.0f;
    private static ArrowTower _instance;
    public static ArrowTower instance
    {
        get
        {
            return _instance;
        }
    }


    void Start()
    {

        this.attackForce = 5.0f;
        this.attackRange = 3.5f;
        this.attackSpeed = 2.0f;
    }
    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        float distance;
        for (int i = 0; i <CreateDoor.instance.enemies.Count; i++)      //每一帧都遍历一遍列表，找到攻击范围内编号最小的敌人
        {
            if (CreateDoor.instance.enemies[i] == null)
            {
                continue;
            }
            distance = Vector3.Distance(CreateDoor.instance.enemies[i].transform.position, transform.position);
            if (distance < attackRange)             //距离判断
            {
                index = i;                          //锁定
                ifAttack = true;                    //初步判定是否攻击
                break;
            }
        }
        if (CreateDoor.instance.enemies.Count > 0 && CreateDoor.instance.enemies[index] != null)
        {

            if (ifAttack && Time.time > nextFire)
            {
                ifAttack = true;
            }
            else
            {
                ifAttack = false;

            }
            if (ifAttack)       //最终判定
            {
                GameObject go = Instantiate(arrow, transform.position, Quaternion.identity);              
                go.GetComponent<Arrow>().arrowTower = this;
                nextFire = Time.time + 1 / attackSpeed; //攻速相关
            }

        }
    }
}


