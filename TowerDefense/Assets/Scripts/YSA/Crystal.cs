using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float hp = 100.0f;

    private void Update()
    {
        IfCollision(Vector3.up);
        IfCollision(Vector3.down);
        IfCollision(Vector3.left);
        IfCollision(Vector3.right);
    }

    private void IfCollision(Vector3 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 0.5f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        //撞到东西，并且还要是锁定的那一个敌人
        {
            hp -= 5;
            Destroy(hit.collider.gameObject);
            if (hp <= 0)
            {
                
            }
        }
    }
}
