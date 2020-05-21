using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Coppers : MonoBehaviour
{
    //이 스크립트는 구리에 대한 스크립트입니다
    //플레이어 상호 작용으로 인해서 일정 시간 동안 채굴당하면 
    //자신 보다 작은 분신을 2~5개정도를 분열해서 던져줍니다
    //채굴 시간은 플레이어가 장비하고 있는 장비에 따라 시간이 달라집니다

    bool mining;

    //채굴에 걸리는 시간을 계산해줍니다
    float currT;
    // Start is called before the first frame update


    public float cubeSize = 0.2f;
    public int cubeInRow = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mining)
        {
            Ore();
        }
    }

    //모든 광석에 상속될 함수이기때문에 이름을 Ore로 정함
    void Ore()
    {
        currT += Time.deltaTime;
        //나중에 하나의 조건을 더 만들어야하는데 그 조건은 
        //플레이어가 무슨 채굴 장비를 가지고 있는지 확인하는 변수입니다
        //지금은 5초라는 시간으로 만들어지만 나중에는 채굴 장비의 종류에 따라
        // 저 시간이 달라집니다
        if(currT >= 5f)
        {
            explode();
        }
    }

    void explode()
    {
        gameObject.SetActive(false);

        for(int x = 0; x < cubeInRow; x++)
            for(int y = 0; y < cubeInRow; y++)
                for(int z = 0;z< cubeInRow; z++)
                {
                    createPiece(x, y, z);
                }
    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //새로 만들어준 큐브들의 위치를 이 스크립트 큐브의 위치로 정해준다
        piece.transform.position = transform.position+ new Vector3(cubeSize *x, 
            cubeSize*y, cubeSize*z);
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //만들어내는 큐브에 리지드바디를 넣어주고 그 무게를 0.2f 바꿔줍니다
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }


    private void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            //충돌 대상이 플레이어면 채굴이 가능합니다
            mining = true;
        }
    }
}
