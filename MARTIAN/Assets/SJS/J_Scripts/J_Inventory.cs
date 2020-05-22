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
   public void ClicksItem(string name, Sprite ima)
    {
        print("인벤토리 안입니다");
        foreach(GameObject a in items)
        {
            J_Slots j_Slots = a.GetComponent<J_Slots>();
            print(j_Slots);
            if(j_Slots.Image.activeSelf == true && j_Slots.name == name)
            {
                j_Slots.ToSum();
                break;
            }

            else if (j_Slots.Image.activeSelf== false)
            {
                j_Slots.Image.SetActive(true);
                print("들어가는 중입니다");
                j_Slots.MySeilf(name, ima);
                break;
            }
        }
    }


    //이 함수는 리스트의 모든 내용 물을 검사하여 중복 되는 것이 있으면 합쳐 줍니다

}