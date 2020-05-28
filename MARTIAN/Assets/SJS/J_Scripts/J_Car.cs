﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Car : MonoBehaviour
{
    //현재 이 차량은 고장난 상태입니다 
    //특정 재료를 모아와야 이 차량을 수리할 수 있습니다 
    //현재 이 차는 고장난 상태입니다
    bool carstate = false;

    bool onPlayerTrigger;

    //이 게임 오브젝트에서 모든 재료를 모아서 수리를 했는지에 대한 검사를 해줄것이다 
    public GameObject carneedwindow;


    //상태 머신하나 만들어서 관리하는게 좋겠네 ㅅㅂ
    public enum State
    {
        BROKEN,  //고장
        REPAIR,  //수리
        ONBOARD  //탑승
    }

    public State state;
    //총 얼마나 필요한지 표시 해줄 변수입니다 
    public int a;


    //필요한 재료를 검색하는데 사용될 이름 저장 배열변수입니다
    public string[] reNeed;

    //이름으로 검색한 인덱스를 기준으로 필요한 수량만큼 가지고 있는지 체크하는 배열 변수입니다
    public int[] reAount;


    J_PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<J_PlayerMove>();
        //시작할때 상태는 고장난 상태입니다
        state = State.BROKEN;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.BROKEN)
        {
            Broken();
        }
    }

    void Broken()
    {
        if(onPlayerTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //플레이어 이동을 막습니다  
                carneedwindow.SetActive(!carneedwindow.activeSelf);
                playerMove.myMoveban = !playerMove.myMoveban;
            }
        }
    }


    //차를 수리하기에 필요한 재료들이 전부 있는지 확인해줍니다
    void clicksCarState()
    {
        //아직 차량을 수리하지 못했다는걸 알려준다
        if(carstate==false)
        {

        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            
            onPlayerTrigger = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player") 
        {
            onPlayerTrigger = false;
        }
    }
}
