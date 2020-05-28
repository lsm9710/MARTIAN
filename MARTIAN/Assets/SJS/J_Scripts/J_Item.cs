using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Item : MonoBehaviour
{
    //아이템 이름
    public string itemName;
    //아이템 이미지
    public Sprite itemImage;
    //아이템 갯수
    public int auount;

    //여기에 아이템 타입을 저장해줄 변수를 만들어야합니다 

    [HideInInspector]
   public bool click;

    public void aaa() 
    {
        if (click == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                print("활성화 합니다");
                //아이템 메니저에게 내 자신의 정보를 넣어준다
                J_ItemManager.j_Item.ClicksItem(gameObject);
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            print(coll.gameObject.name);
            click = true;
        }
    }
}
