using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropsManager : MonoBehaviour
{
    //들고있는 작물에 상호작용하고 싶다.
    //작물을 들고 있는지는 어떻게 알것인가?
    //인벤토리에서 선택한 작물이 들고있는 작물이다.

    public enum WhatCrops
    {
        WATER,
        POTATO,
        CARROT,
        RADISH
    }
    public WhatCrops state;

    public GameObject rayStart;
    public float rayDis;
    public float angle;

    RaycastHit rayHit;

    //공장주소
    public GameObject potatoFactory;
    public GameObject carrotFactory;
    public GameObject radishFactory;

    CalorieLevle cl;

    //인벤토리를 열었는지 체크할 불변수
    public bool isInven;

    // Start is called before the first frame update
    void Start()
    {
        cl = gameObject.GetComponent<CalorieLevle>();
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
            case WhatCrops.POTATO:
                if (isInven) return;
                if (Input.GetButtonDown("Fire1")) PlantCrops(potatoFactory);
                if (Input.GetKeyDown(KeyCode.E)) cl.h_CurrentHunger += 5f;
                break;
            case WhatCrops.CARROT:
                if (isInven) return;
                if (Input.GetButtonDown("Fire1")) PlantCrops(carrotFactory);
                if (Input.GetKeyDown(KeyCode.E)) cl.h_CurrentHunger += 7f;
                break;
            case WhatCrops.RADISH:
                if (isInven) return;
                if (Input.GetButtonDown("Fire1")) PlantCrops(radishFactory);
                if (Input.GetKeyDown(KeyCode.E)) cl.h_CurrentHunger += 3f;
                break;
            case WhatCrops.WATER:
                if (isInven) return;
                if (Input.GetButtonDown("Fire1")) SprinkleWater();
                if (Input.GetKeyDown(KeyCode.E)) cl.t_CurrentThirsty += 10f;
                break;
        }
    }

    //감자심기
    private void PlantCrops(GameObject plantCrops)
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward * rayDis + rayStart.transform.up * angle);
        Debug.DrawRay(rayStart.transform.position, rayStart.transform.forward * rayDis + rayStart.transform.up * angle, Color.green);

        if (Physics.Raycast(ray, out rayHit, rayDis, (1 << 12)))
        {
            GameObject PreparedLand = rayHit.transform.gameObject;
            GameObject plant = Instantiate(plantCrops);

            plant.transform.position = PreparedLand.transform.position;
        }
    }

    private void SprinkleWater()
    {
        Ray ray = new Ray(rayStart.transform.position, rayStart.transform.forward * rayDis + rayStart.transform.up * angle);
        Debug.DrawRay(rayStart.transform.position, rayStart.transform.forward * rayDis + rayStart.transform.up * angle, Color.blue);

        if (Physics.Raycast(ray, out rayHit, rayDis, (1 << 12)))
        {
            MeshRenderer mr = rayHit.transform.gameObject.GetComponent<MeshRenderer>();
            mr.material.color = new Color(89f, 36, 28);

            //물 카운트를 줄인다.
        }
    }

}
