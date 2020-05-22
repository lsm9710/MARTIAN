using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Item : MonoBehaviour
{
    public string itemName;
    public Image itmeImage;

    bool click;


    private void Update()
    {
        if(click)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                J_Inventory.j_Inventory.ClicksItem(itemName, itmeImage);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            click = true;
        }
    }
}
