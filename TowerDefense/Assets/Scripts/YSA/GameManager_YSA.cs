using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_YSA : MonoBehaviour
{
    private static GameManager_YSA instance;
    public static GameManager_YSA Instance
    {
        get
        {
            return instance;
        }

    }

    private void Awake()
    {
        instance = this;
    }

    GameObject m;
    public Money mClass;
    public int money;

    private void Update()
    {
        if (GameObject.Find("MoneyText") != null)
        {
            m = GameObject.Find("MoneyText");
            mClass = m.GetComponent<Money>();
            money = mClass.num;
        }

    }
}
