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

    public int sum;
    Image mainImage;
    Text texts;

    private void Start()
    {
        mainImage = Image.GetComponent<Image>();
        texts = text.GetComponent<Text>();
    }

    public void ToSum()
    {
        sum++;
        texts.text = sum.ToString();
    }
    public void MySeilf(string IName, Sprite IIamge)
    {
        mainImage.sprite = IIamge;
        name = IName;
        sum++;
    }
}
