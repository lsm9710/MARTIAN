using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemImage;
    public int auount;

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
