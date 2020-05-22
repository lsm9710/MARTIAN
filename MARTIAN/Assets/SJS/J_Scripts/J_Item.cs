using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Item : MonoBehaviour
{
    
    [HideInInspector]
   public bool click;

    public void aaa(string itemName, Sprite itmeImage) 
    {
        print(click);
        if (click == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                print("활성화 합니다");
                J_Inventory.j_Inventory.ClicksItem(itemName, itmeImage);
                Destroy(gameObject);
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
