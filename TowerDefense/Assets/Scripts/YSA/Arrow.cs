using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public ArrowTower arrowTower;

    public float arrowSpeed = 3.0f;


    private void Update()
    {
        if (arrowTower.enemies.Count < arrowTower.index)
        {
            return;
        }
        if (arrowTower.enemies[arrowTower.index] == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = arrowTower.enemies[arrowTower.index].transform.position - transform.position; // 得到方向

        if (direction.y < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 180);      //根据相对位置调整旋转方向
        }

        transform.Rotate(new Vector3(0, 0, GetAngle(direction)));         //转
        transform.Translate(Vector3.up * arrowSpeed * Time.deltaTime);
        IfCollision(direction);
    }

    private void IfCollision(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 0.5f);
        if (hit.collider != null && hit.collider.gameObject == arrowTower.enemies[arrowTower.index])
        //撞到东西，并且还要是锁定的那一个敌人
        {
            hit.collider.gameObject.GetComponent<Enemy>().hp -= arrowTower.attackForce;
            Destroy(gameObject);
        }
    }


    private float GetAngle(Vector3 dir)     //得到要转向的角度
    {
        if (Vector3.Angle(transform.up, Vector3.right) < Vector3.Angle(dir, Vector3.right))
        {
            return Vector3.Angle(transform.up, dir);
        }
        else
        {
            return -Vector3.Angle(transform.up, dir);
        }
    }
}

