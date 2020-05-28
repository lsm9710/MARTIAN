﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_CarRepair : MonoBehaviour
{
    public J_Car j_Car;
    public GameObject stuff;

    public bool[] s;

    public Sprite[] sprites;
    public int aountMat;
    public GameObject materials;
    public string[] names;
    public int[] spriteAount;



    public void Test()
    {
        //총 몇개의 재료가 있는지 확인하고 그만큼 for를 돌려서 검사합니다 
        for (int i = 0; i < aountMat; i++)
        {
            //제작 버튼의 활성화를 검사하기 위한 bool문입니다 
            s[i] = true;
        }



        //여기는 메뉴가 아니라 다른 곳입니다 그곳에 맞개 수정해줘야합니다
        /*if (J_Mune.mune.buttonNmb != null)
        {
            for (int i = 0; i < materials.transform.childCount; i++)
            {
                //부모 아래의 자식 게임오브젝트를 삭제하겠다고 알려줍니다
                Destroy(materials.transform.GetChild(i).gameObject);
            }
        }*/

        for (int i = 0; i < aountMat; i++)
        {
            //매뉴에 지금 내가 들어갔다고 알려준다
            
            for (int j = 0; j < J_ItemManager.j_Item.items2.Length; j++)
            {
                if (J_ItemManager.j_Item.items2[j] != null)
                {
                    print("비어있지 않습니다" + J_ItemManager.j_Item.items2[j]);
                    if (names[i] == J_ItemManager.j_Item.items2[j].itemName)
                    {
                        print("동일합니다" + names[i] + " / " + J_ItemManager.j_Item.items2[j].itemName);
                        print(J_ItemManager.j_Item.items2[j].auount);
                        print(spriteAount[i]);
                        //서로 다르기 때문에 앞쪽은 빨강색 뒷 색은 검은색으로표시해줍니다   
                        if (J_ItemManager.j_Item.items2[j].auount < spriteAount[i])
                        {
                            print("서로 다른 값을 가지고 있습니다");
                            //텍스트를 빨강색으로 표시해줍니다
                            stuff.GetComponentInChildren<Text>().text = "<color=#ff0000>" +
                                J_ItemManager.j_Item.items2[j].auount.ToString() + "</color>" +
                                 //월래색인 검은색으로 표시합니다
                                 "/" + spriteAount[i].ToString();
                            s[i] = false;
                        }
                        //필요 재료량보다 가지고 있는 수가 더 많을 수도 있다
                        else if (J_ItemManager.j_Item.items2[j].auount >= spriteAount[i])
                        {
                            print("같은 값을 가지고 있어 확인되었습니다");
                            stuff.GetComponentInChildren<Text>().text =
                                J_ItemManager.j_Item.items2[j].auount.ToString() +
                            "/" + spriteAount[i].ToString();
                            s[i] = false;
                        }
                    }
                    else
                    {
                        stuff.GetComponentInChildren<Text>().text = "<color=#ff0000>" +
                                0 + "</color>" +
                                 "/" + spriteAount[i].ToString();

                    }
                }
                else if (s[i] == true)
                {
                    print("설마 들어오냐?");
                    stuff.GetComponentInChildren<Text>().text = "<color=#ff0000>" +
                                0 + "</color>" +
                                 "/" + spriteAount[i].ToString();
                }
            }
            stuff.GetComponent<Image>().sprite = sprites[i];
            //서로 갯수가 다르면 플레이어 측 아이템 색을 빨강색으로 표시 합니다
            //즉 아이템 만드는데 필요한 수량이 부족하다는것은 적다는 것이다 


            GameObject a = Instantiate(stuff);
            a.transform.SetParent(materials.gameObject.transform);
        }
    }
}
