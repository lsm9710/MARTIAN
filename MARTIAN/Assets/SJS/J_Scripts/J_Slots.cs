using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Slots : J_SlotButtons
{
    //이 스크립트는 슬롯을 관리 해주는 스크립트입니다 
    //이 스크립트와 인벤토리 스크립트는 같이 사용 됩니다


    public GameObject mainIamge;
    public Image Image;
    public Text text;
    public string name;
    public GameObject itemMy;

    J_PlayerMove player;

    Button button;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<J_PlayerMove>();
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);

    }
    private void Start()
    {
    }
    public void MySeilf(string IName, Sprite IIamge, int sum)
    {
        name = IName;
        Image.sprite = IIamge;
        text.text = sum.ToString();
    }


    //이 함수는 버튼을 클릭하면 나오는 이미지나 사용 법등을 출력해줄 ui사용 버튼입니다

    public void ButtonClick()
    {
        _Slots = gameObject;
        ButtonClicks();

    }
}
