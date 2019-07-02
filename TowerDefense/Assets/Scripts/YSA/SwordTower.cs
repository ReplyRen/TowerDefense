using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTower : Tower
{
    public List<GameObject> enemies = new List<GameObject>();  //敌人的列表
    private List<float> nextFireTime = new List<float>() { 0, 0, 0, 0 };   // 每个敌人所对应的被攻击的间隔时间
    private bool ifAttack = true;
    private void Start()
    {
        this.attackForce = 10.0f;
        this.attackRange = 5.0f;
        this.attackSpeed = 2.0f;
    }

    private void Update()
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                //RemoveAt(i);
                continue;
            }
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position); // 相聚距离
            if (Time.time > nextFireTime[i] && distance < attackRange)
            {
                ifAttack = true;
            }
            else
            {
                ifAttack = false;
            }

            if (ifAttack) // 攻速相关
            {
                if (enemies[i].gameObject.GetComponent<Enemy>().hp <= attackForce)
                {
                    enemies[i].gameObject.GetComponent<Enemy>().hp -= attackForce;
                    enemies.RemoveAt(i);        //删除已死亡的Enemy
                    nextFireTime.RemoveAt(i);   //删除其对应的间隔时间
                    i--;
                }
                else
                {
                    enemies[i].gameObject.GetComponent<Enemy>().hp -= attackForce;
                    nextFireTime[i] = Time.time + 1 / attackSpeed; //攻速相关
                }


            }
        }
    }



}
