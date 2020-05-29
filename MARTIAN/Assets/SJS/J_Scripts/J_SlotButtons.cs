using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_SlotButtons : MonoBehaviour
{
    //이 스크립트는 슬롯을 클릭하면 ui가 나타나는 스크립트입니다
    //나타나는 ui들은 여러가지 선택지를 고를수 있게 합니다 

    public enum State
    {
        MYINVENYROY,
        LOCKER,
        LOCKERINVENTROY
    }

    public State state;


    public GameObject slotButton;
    public Button button;
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
                break;
            case State.LOCKERINVENTROY:
                break;
        }
    }

    //단지 자기 자신의 인벤토리를 열었다면 
    void Myinv()
    {

    }

    //창고를 열었다면
    void Locker()
    { 

    }

    //창고 인벤토리를 열었다면
    void LockerInv()
    {

    }
}
