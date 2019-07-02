using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100.0f;          //血量
    public float speed = 2.0f;         //移动速度

    private void Update()
    {
        Move(new Vector3(1, 0, 0));  //测试
        if(hp <= 0)
        {
            Dead();
        }
    }

    private void Move(Vector3 dir)     //移动
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void Dead()                //死亡
    {
        Destroy(gameObject);
    }
}
