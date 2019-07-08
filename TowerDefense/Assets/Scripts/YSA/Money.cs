using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    Text money;
    public int num = 100;

    private void Start()
    {
        money = GetComponent<Text>();
    }

    public void ChangeMoney(int param)
    {
        if((num + param) >= 0)
        {
            num += param;
            money.text = num.ToString();
        }
        
    }

    public void LackMoney(string str)
    {
        money.text = str;
    }

}
