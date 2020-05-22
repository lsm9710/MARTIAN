using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_PlayerMove : MonoBehaviour
{
    //이 스크립트는 플레이어의 기본 이동을 해줄 스크립트입니다

    //방향키 입력을 받아 줄 변수가 필요합니다
    //상하 좌우의 입력을 받아 줍니다
    //기억하세요
    float h;
    float v;

    //인벤토리 오브젝트를 할당해줍니다
    public GameObject inv;
    //플레이어의 좌표를 할당 받을 변수입니다
    Vector3 myDir = Vector3.zero;
    //이동을 위한 스피드 값입니다
    public float speed = 7f;
    //플레이어는 캐릭터 컨트롤러로 움직일 겁니다
    CharacterController cc;

    public bool onAction;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
        //인벤토리가 켜지면 바로 탈출하여 아래 코드를 막는다 
        if(inv.activeSelf)
        {
            return;
        }
        //GetAxisRaw 사용한 이유는 키보드로 작동하는 게임이기 때문에 0 1 -1 이외의 값은
        //불필요합니다
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.E))
        {
            onAction = true;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            onAction = false;
        }


        myDir = new Vector3(h, 0, v);
        myDir = transform.TransformDirection(myDir);
        myDir *= speed;
        cc.Move(myDir * Time.deltaTime);
        MouseXRot();
    }

    //마우스 x 좌표 값을 받을 변수입니다
    float mouseX;
    //회전 속도 입니다
    public float rotSpeed = 200f;
    void MouseXRot()
    {
        mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(mouseX * rotSpeed * transform.up);
    }



    void PlayerInputs()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inv.SetActive(!inv.activeSelf);
        }
    }
}
