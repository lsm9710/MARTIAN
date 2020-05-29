using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_SlotButtons : MonoBehaviour
{
    //이 스크립트는 슬롯을 클릭하면 ui가 나타나는 스크립트입니다
    //나타나는 ui들은 여러가지 선택지를 고를수 있게 합니다 

    //지금 무슨 슬롯이 선택 되었는지 확인하기 위한 게임오브젝트입니다


    public enum State
    {
        MYINVENYROY,
        LOCKER,
        LOCKERINVENTROY
    }

    public State state;

    //지금 무슨 슬롯이 선택되었는지 알려주기 위한 변수입니다
    public GameObject _Slots;


    public GameObject slotButton;
    public Button button;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //아래 방법으로 사용하면 버튼을 생성하자마자 함수를 등록해줄수 있다
        //button.onClick.AddListener(() => print("버튼 클릭!"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicks()
    {
        switch(state)
        {
            case State.MYINVENYROY:
                Myinv();
                break;
            case State.LOCKER:
                Locker();
                break;
            case State.LOCKERINVENTROY:
                LockerInv();
                break;
        }
    }

    //단지 자기 자신의 인벤토리를 열었다면 
    void Myinv()
    {
        Contents("버리기", "취소");
    }

    //창고를 열었다면
    void Locker()
    {
        Contents("빼내기", "취소");
    }

    //창고 인벤토리를 열었다면
    void LockerInv()
    {
        Contents("집어 넣기", "취소");
    }

    void Contents(string text1, string text2)
    {
        if (slotButton.transform.childCount > 0)
        {
            for (int i = 0; i < slotButton.transform.childCount; i++)
            {
                Destroy(slotButton.transform.GetChild(i).gameObject);
            }
        }
        slotButton.SetActive(true);
        Button a = Instantiate(button);
        a.onClick.AddListener(Actions2);

        a.GetComponentInChildren<Text>().text = text1;
        a.transform.SetParent(slotButton.transform);

        Button b = Instantiate(button);
        b.onClick.AddListener(Actions);
        b.GetComponentInChildren<Text>().text = text2;
        b.transform.SetParent(slotButton.transform);
    }

    void Actions()
    {
        slotButton.SetActive(false);
    }

    void Actions2()
    {
        J_Slots a = _Slots.GetComponent<J_Slots>();

        //자기 인벤토리에서 실행하는 상태입니다
        if (state == State.MYINVENYROY)
        { 
            for(int i = 0; i < 
                J_ItemManager.j_Item.items2.Length; i++)
            {
                if(J_ItemManager.j_Item.items2[i].itemName == a.name)
                {
                    J_ItemManager.j_Item.items2[i].auount--;

                    //만약 슬롯의 아이템 갯수가 0이면 그 자리를 비워줘야합니다
                    if(J_ItemManager.j_Item.items2[i].auount ==0)
                    {
                        //아이템이 없기 때문에 이미지도 비활성화 해줍니다 

                        print(J_ItemManager.j_Item.items2[i]);
                        J_ItemManager.j_Item.items2[i].GetComponent<J_Slots>().mainIamge.SetActive(false);
                            
                        //아이템이 없기 때문에 null값을 넣어줍니다
                        J_ItemManager.j_Item.items2[i] = null;
                        
                
                    }
                    break;
                }
            }

            GameObject mm = Instantiate(a.itemMy);
            mm.SetActive(true);
            mm.transform.position = player.transform.position;
        }
        //창고에서 인벤토리로 꺼내는 조건입니다
        else if(state == State.LOCKER)
        {

        }
        //자신 인벤토리에서 창고로 넣어주는 상태입니다
        else if(state == State.LOCKERINVENTROY)
        {

        }
    }
}
