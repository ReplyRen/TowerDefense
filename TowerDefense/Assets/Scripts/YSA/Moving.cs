using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject tower;
    private bool ifBuild = true;
    private void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));      
        if (Input.GetMouseButton(0))
        {

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D [] hit = Physics2D.RaycastAll(worldPos, new Vector3(0, 0, 1), 20.0f);

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.tag == "Tower")
                {
                    ifBuild = false;
                    break;
                }
            }

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.gameObject.tag == "TowerBase")
                {

                    if(GameManager_YSA.Instance.money >= 25 && ifBuild)
                    {
                        Instantiate(tower, hit[i].collider.gameObject.transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        GameManager_YSA.Instance.mClass.ChangeMoney(-25);
                    }
                    else
                    {
                        GameManager_YSA.Instance.mClass.LackMoney("金钱不足");
                    }
                    Destroy(gameObject);
                }
            }
            
        }

        if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }

            
    }



    //private void OnMouseDown()
    //{
    //    // a 创建射线
    //    Debug.Log(2);
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// 从摄像机发射出一条经过鼠标当前位置的射线
    //    // b 发射射线
    //    RaycastHit hitInfo = new RaycastHit();
    //    if(Physics.Raycast(ray, out hitInfo))
    //    {
    //        Debug.Log(3);
    //        if (hitInfo.collider.gameObject.tag == "TowerBase")
    //        {
    //            Debug.Log(4);
    //            Instantiate(arrowTower, transform.position, Quaternion.identity);
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
