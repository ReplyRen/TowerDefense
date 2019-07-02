using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float hp = 100.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        hp -= 5;
        if (hp <= 0)
        {
            Application.Quit();
        }
    }
}
