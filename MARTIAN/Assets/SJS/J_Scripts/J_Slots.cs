using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Slots : MonoBehaviour
{
    //이 스크립트는 슬롯을 관리 해주는 스크립트입니다 
    //이 스크립트와 인벤토리 스크립트는 같이 사용 됩니다


     
    public GameObject Image;
    public GameObject text;
    public string name;

    //채굴한 아이템의 이미지
    Image mainImage;
    //채굴한 아이템의 갯수
    Text texts;

    private void Start()
    {
        mainImage = Image.GetComponent<Image>();
        print(mainImage);
        texts = text.GetComponent<Text>();
    }
    public void MySeilf(string IName, Sprite IIamge, int sum)
    {
        name = IName;
        print(mainImage);
        mainImage.sprite = IIamge;
        texts.text = sum.ToString();
    }
}
