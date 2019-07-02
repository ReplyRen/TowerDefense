using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public float hp;
    public float attack;
    public float moveSpeed;
    public float attackSpeed;
    public GameObject[] targets;
    private bool isWin = false;
    public float timer;
    private void Start()
    {

    }
    public void Update()
    {
        timer += Time.deltaTime;
        if (gameObject.tag == "Army")
            targets = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Enemy;
        else if(gameObject.tag=="Enemy")
            targets = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().Army;
        if (!isWin)
        {
            int index = FindMinTarget();
            if(targets.Length>0)
                Move(targets[index]);
        }
    }
    public void Move(GameObject target)
    {
        Vector3 dir = new Vector3();
        dir = (target.transform.position - transform.position) / Vector3.Distance(target.transform.position, transform.position);
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    private int FindMinTarget()
    {
        float distance = 100f;
        int index = 0;
        for(int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
            {
                if (Vector3.Distance(transform.position, targets[i].transform.position) < distance)
                {
                    distance = Vector3.Distance(transform.position, targets[i].transform.position);
                    index = i;
                }
            }
        }
        return index;
    }

}
