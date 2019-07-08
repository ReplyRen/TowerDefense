using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTower : Tower
{
    private bool ifAttack = true;
    private bool ifHit = false; //是否放动画
    private void Start()
    {
        this.attackForce = 10.0f;
        this.attackRange = 1.5f;
        this.attackSpeed = 2.0f;
    }

    private void Update()
    {
        ifHit = false;

        for (int i = 0; i < CreateDoor.instance.enemies.Count; i++)
        {
            
            if (CreateDoor.instance.enemies[i] == null)
            {
                continue;
            }
            float distance = Vector3.Distance(CreateDoor.instance.enemies[i].transform.position, transform.position); // 相聚距离
            if (Time.time > CreateDoor.instance.nextFireTime[i] && distance < attackRange)
            {
                ifAttack = true;
            }
            else
            {
                ifAttack = false;
            }

            if (ifAttack) // 攻速相关
            {
                if ((CreateDoor.instance.enemies[i].transform.position.x - transform.position.x) > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                //gameObject.GetComponent<Animator>().enabled = true;
                if (CreateDoor.instance.enemies[i].gameObject.GetComponent<Enemy>().hp <= attackForce)
                {
                    CreateDoor.instance.enemies[i].gameObject.GetComponent<Enemy>().hp -= attackForce;
                }
                else
                {
                    CreateDoor.instance.enemies[i].gameObject.GetComponent<Enemy>().hp -= attackForce;
                    CreateDoor.instance.nextFireTime[i] = Time.time + 1 / attackSpeed; //攻速相关
                }
            }

            if (distance < attackRange)
            {
                ifHit = ifHit|| true;
                Debug.Log(222);
            }
            else
            {
                ifHit =ifHit || false;
            }
           
        }
        gameObject.transform.Find("Tower_child").GetComponent<Animator>().enabled = ifHit;
    }
}
