﻿using System.Collections;
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
    public int auount =1;

    public GameObject my;
    //여기에 아이템 타입을 저장해줄 변수를 만들어야합니다 
    public enum ItemType
    {
        WEAPON,  //장비
        Consumer, //소비
        STONE,  //원석
    }

    public ItemType type;

    [HideInInspector]
   public bool click;

    public void aaa() 
    {
        if (click == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GameObject a = Instantiate(gameObject);
                a.SetActive(false);
                //아이템 메니저에게 내 자신의 정보를 넣어준다
                J_ItemManager.j_Item.ClicksItem(a);
                //Destroy(gameObject);
                gameObject.SetActive(false);
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
    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            click = false;
        }
    }
}
