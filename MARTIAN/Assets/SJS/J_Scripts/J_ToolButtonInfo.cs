using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_ToolButtonInfo : MonoBehaviour
{
    //버튼을 클릭하면 그 버튼의 만드는데 필요한 재료를 알수 있습니다

    public GameObject stuff;
    //이건 각 재료들의 갯수에 맞추어 이미지를 소환해 줄 int 변수입니다
    public int aountMat;

    //이미지 사진을 넣어둘 스프라이트 변수 배열입니다
    public Sprite[] sprites;

    //각이미지에 있는 재료들의 갯수를 알려줍니다
    public int[] spriteAount;

    //재료들의 이름을 아이템 데이터 베이스에서 찾아올 검색용 이름 배열입니다
    public string[] names;
    //이미지를 보여줄 메인 프렌을 외부 참조로 받아옵니다
    public GameObject materials;

    public Button my;

    // Start is called before the first frame update
    void Start()
    {
        my = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //또 다른 문제점 자신을 계속해서 클릭하면 누적되는것이 아니라 선택을 못하게 막아야한다
    int setSum;
    public void OnButtons()
    {
        if (J_Mune.mune.buttonNmb != null)
        {
            J_Mune.mune.buttonNmb.GetComponent<Button>().interactable = true;
            for (int i = 0; i < materials.transform.childCount; i++)
            {
                //부모 아래의 자식 게임오브젝트를 삭제하겠다고 알려줍니다
                Destroy(materials.transform.GetChild(i).gameObject);
            }
        }




        for (int i = 0; i < aountMat; i++)
        {
            //매뉴에 지금 내가 들어갔다고 알려준다
            J_Mune.mune.buttonNmb = gameObject;
            my.interactable = false;
            for (int j = 0; j < J_ItemManager.j_Item.items2.Length; j++)
            {
                if (J_ItemManager.j_Item.items2[j] != null)
                    if (names[i] == J_ItemManager.j_Item.items2[j].itemName)
                    {
                        setSum = J_ItemManager.j_Item.items2[j].auount;
                    }
            }
            stuff.GetComponent<Image>().sprite = sprites[i];
            //서로 갯수가 다르면 플레이어 측 아이템 색을 빨강색으로 표시 합니다
            //즉 아이템 만드는데 필요한 수량이 부족하다는것은 적다는 것이다 
            if (setSum < spriteAount[i])
            {
                stuff.GetComponentInChildren<Text>().text = "<color=#ff0000>" + setSum.ToString() + "</color>" +
                     "/" + spriteAount[i].ToString();
            }
            //필요 재료량보다 가지고 있는 수가 더 많을 수도 있다
            else if(setSum >= spriteAount[i])
            {
                stuff.GetComponentInChildren<Text>().text = setSum.ToString() +
                "/" + spriteAount[i].ToString();

            }

            GameObject a = Instantiate(stuff);
            a.transform.SetParent(materials.gameObject.transform);
        }
    }
}
