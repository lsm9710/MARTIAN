﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_ItemManager : MonoBehaviour
{
   public static J_ItemManager j_Item;

    public J_Item[] items2 = new J_Item[21];
    //아이템의 정보를 관리해 줄 변수배열입니다
    //public GameObject[] items;

    J_PlayerMove player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<J_PlayerMove>();
        j_Item = this;
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player.invClics)
        {
            for (int i = 0; i < items2.Length; i++)
            {
                J_Slots s = J_Inventory.j_Inventory.items[i].GetComponent<J_Slots>();
                if(items2[i] !=null)
                {
                    s.mainIamge.SetActive(true);
                    s.Image.sprite = items2[i].itemImage;
                    s.text.text = items2[i].auount.ToString();
                    s.name = items2[i].itemName;
                }                                   
            }
        }  
    }

    public void ClicksItem(GameObject x)
    {
        for (int i = 0; i < items2.Length; i++)
        {
            J_Item j_Item = x.GetComponent<J_Item>();
            print(items2[i]);
            //가장 먼저 배열 클래스에 자신과 동일한 것이 있는지 확인해줍니다 
            //있으면 갯수만 늘려주고 탈출합니다
            if (items2[i] != null)
            {
                if (items2[i].itemName == j_Item.itemName)
                {
                    items2[i].auount++;
                    break;
                }
            }
            //해당 배열클래스의이름이 비어있으면 그 배열 클래스로 정해줍니다
            else if (items2[i] == null)
            {
                items2[i] = j_Item;
                items2[i].auount++;
                items2[i].itemImage = j_Item.itemImage;
                //받아드려오는 오브젝트의 내부속 이름
                // items2[i].itemName = j_Item.itemName;
                //오브젝트의 이미지 스프라이트 설정해줍니다
                // items2[i].itemImage = j_Item.itemImage;
                // items2[i].auount++;
                break;
            }
        }
    }
}
