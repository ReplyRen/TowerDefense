using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Army
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (timer > attackSpeed)
        {
            timer = 0;
            Attake();
        }
    }
    private void Attake()
    {
        Debug.Log(0);
    }
}
