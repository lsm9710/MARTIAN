using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_ToolMakeButton : MonoBehaviour
{
    //이 스크립트는 재료가 만족할 시 클릭하면 그 완성품을 만들어서 밷어준다

    //자기자신의 버튼 컨퍼넌트를 받아옵니다
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        //툴창을 열고 닫을때 시작은 무조건 비활성화입니다
        button.interactable = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(J_Mune.mune.buttonNmb != null)
        {
            //무슨 버튼이 클릭되어있으면 제작버튼을 활성화 시켜줍니다
            button.interactable = true;
        }
    }

    //버튼을 클릭하면 실행합니다
    public void ButtonDClicks()
    {
        J_ToolButtonInfo x = J_Mune.mune.buttonNmb.GetComponent<J_ToolButtonInfo>();
        
        
        for (int i = 0; i < J_ItemManager.j_Item.items2.Length; i++)
        {
            if(J_ItemManager.j_Item.items2[i] != null)
            {
                for (int j = 0; j < x.names.Length; j++)
                {
                    if (J_ItemManager.j_Item.items2[i].itemName == x.names[j])
                    {
                        //다시 자기자신에게 넣어주는것
                        J_ItemManager.j_Item.items2[i].auount -= x.spriteAount[j];
                        x.OnButtons();
                        if (J_ItemManager.j_Item.items2[i].auount == 0)
                        {
                            J_ItemManager.j_Item.items2[i] = null;
                        }
                    }
                }
            }           
        }
       
    }
}
