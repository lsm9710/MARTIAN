using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Inventory : MonoBehaviour
{
    public static J_Inventory j_Inventory;
    //이 리스트 아이템 보관 및 정보를 담을 변수리스트입니다
    public List<GameObject> items = new List<GameObject>();
    //이 스크립트는 인벤토리 스크립트 입니다 
    //즉 플레이어가 확득한 아이템을 관리 해줍니다.
    // Start is called before the first frame update
    private void Awake()
    {
        j_Inventory = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void ClicksItem(string name, Image ima)
    {
        foreach(GameObject a in items)
        {
            if(a.transform.Find("Iamge").gameObject.activeSelf== false)
            {
                a.transform.Find("Iamge").GetComponent<J_Slots>().IName = name;
                a.transform.Find("Iamge").GetComponent<J_Slots>().IIamge = ima;

            }

        }
    }
}