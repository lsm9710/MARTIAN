using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilCondition : MonoBehaviour
{
    //내 상태가 물에 젖은 상태라면 시간을 세고싶다.
    //상태부터 만들어야겠네
    public enum AmIWet
    {
        NO,
        Yes
    }
    public AmIWet state;

    float currentTime;
    //실제시간 20분을 초로 환산하면..?
    public float maxWetTime = 1200f;
    //작물이 자라는 쿨타임을 저장할 변수
    public float growCool = 5f;

    public GameObject cropFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SWITCH();
    }

    private void SWITCH()
    {
        switch (state)
        {
            case AmIWet.NO:
                break;
            case AmIWet.Yes:
                CountTime();
                break;
        }
    }

    private void CountTime()
    {
        //시간을 세고싶다
        currentTime += Time.deltaTime;
        //얼마까지셀거냐
        if (currentTime <= maxWetTime)
        {
            StartCoroutine(GrowCrops());
        }
        else StopAllCoroutines();
    }
    IEnumerator GrowCrops()
    {
        yield return new WaitForSeconds(growCool);
        GameObject a = gameObject.transform.GetComponentInChildren<GameObject>();
        Destroy(a);
        GameObject myChild = Instantiate(cropFactory);
        myChild.transform.position = transform.position;
        myChild.transform.SetParent(transform);
        yield return new WaitForSeconds(growCool);
        myChild.transform.localScale +=  new Vector3(0.3f,0.3f,0.3f);
    }
}
