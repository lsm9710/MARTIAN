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
    //그냥 취소버튼
    public Button button2;

    Button clickButton;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
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
        clickButton = Instantiate(button);
        //소환하면서 지금 누구의 아이템 정보를 전달해줍니다
        //시발 이걸 생각 못했네

        //a.GetComponent
        clickButton.onClick.AddListener(Actions2);
        clickButton.GetComponent<J_SclectButton>().scls = _Slots;
        clickButton.GetComponentInChildren<Text>().text = text1;
        clickButton.transform.SetParent(slotButton.transform);

        Button b = Instantiate(button2);
        b.onClick.AddListener(Actions);
        b.GetComponentInChildren<Text>().text = text2;
        b.transform.SetParent(slotButton.transform);
    }

    void Actions()
    {
        slotButton.SetActive(false);
    }

    string ss2;
    int aa2;
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
                    J_ItemManager.j_Item.items2[i].auount -=
                        clickButton.GetComponent<J_SclectButton>().ss;

                    //만약 슬롯의 아이템 갯수가 0이면 그 자리를 비워줘야합니다
                    if (J_ItemManager.j_Item.items2[i].auount ==0)
                    {
                        //아이템이 없기 때문에 이미지도 비활성화 해줍니다 
                        
                        J_Inventory.j_Inventory.items[i].GetComponent<J_Slots>().mainIamge.SetActive(false);
                            
                        //아이템이 없기 때문에 null값을 넣어줍니다
                        J_ItemManager.j_Item.items2[i] = null;
                                       
                    }
                    break;
                }
            }

           /* GameObject mm = Instantiate(a.itemMy);
            mm.SetActive(true);
            mm.GetComponent<J_Item>().auount = clickButton.GetComponent<J_SclectButton>().ss;
            mm.transform.position = player.transform.position;
            */
            a.itemMy.transform.position = player.transform.position;
            a.itemMy.GetComponent<J_Ore>().auount = clickButton.GetComponent<J_SclectButton>().ss;
            a.itemMy.SetActive(true);
        }
        //창고에서 인벤토리로 꺼내는 조건입니다
        else if(state == State.LOCKER)
        {

        }
        //자신 인벤토리에서 창고로 넣어주는 상태입니다
        
        
        else if(state == State.LOCKERINVENTROY)
        {
            //버튼 클릭시 내가 원하는 정보가 나오는지 확인하기 위해서 사용한 명령어입니다
          

            //잘나옵니다 
            for (int i = 0; i < J_LockerInvs.j_LockerInvs.items.Count;i++ )
            { 
                if(J_LockerInvs.j_LockerInvs.items[i]!= null)
                {
                    
                    //int.Parse(gameObject.GetComponent<J_Slots>().text.text)
                    //J_LockerInvs.j_LockerInvs.items[i] = gameObject.GetComponent<J_Slots>();
                    J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().mainIamge.SetActive(true);
                    if (J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().text.text != null)
                    {
                        J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().MySeilf(gameObject.GetComponent<J_Slots>().name,
                      gameObject.GetComponent<J_Slots>().Image.sprite,
                      clickButton.GetComponent<J_SclectButton>().ss);
                    }
                 
                  

                    //이 위까지 창고로 넣어주는 명령어입니다

                    //아래는 이제 인벤토리에서 지우는 명령어 입니다
                    for(int j = 0; j < J_ItemManager.j_Item.items2.Length; j++ )
                    {
                        //지금 창고에 넣을 아이템 이름과 아이템 메니저의 이름을 검사해서 두개가 동일하면 다음 if문을 실행합니다
                        if(J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().name == J_ItemManager.j_Item.items2[j].itemName)
                        {
                            J_ItemManager.j_Item.items2[j].auount-= clickButton.GetComponent<J_SclectButton>().ss;
                            J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().MySeilf(J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().name,
                                J_LockerInvs.j_LockerInvs.items[i].GetComponent<J_Slots>().Image.sprite, J_ItemManager.j_Item.items2[j].auount);
                            if (J_ItemManager.j_Item.items2[j].auount == 0)
                            {
                               // J_ItemManager.j_Item.items2[j].GetComponent<>
                                J_ItemManager.j_Item.items2[j] = null;
                            }
                            break;
                        }
                    }
                    
                    break;
                }
            }
        }
    }
}
