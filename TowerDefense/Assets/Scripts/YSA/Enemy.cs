using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100.0f;          //血量
    public float speed = 2.0f;         //移动速度
    private List<Transform> pathDots=new List<Transform>();

    private void Start()
    {
        GameObject path = GameObject.FindGameObjectWithTag("Path");
        int num = path.transform.childCount;
        pathDots.Add(gameObject.transform);

        for(int i = 0; i < num; i++)
        {
            pathDots.Add(path.transform.GetChild(i));
        }

    }
    private int index = 0;
    private void Update()
    {
        
        if(Vector3.Distance(pathDots[index].position, transform.position) > 0.1f )
        {
            Vector3 dir = pathDots[index].position - transform.position;
            dir = dir.normalized;
            Move(dir);
        }
        else
        {
            index++;
        }
       

        //Move(new Vector3(1, 0, 0));  //测试
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
