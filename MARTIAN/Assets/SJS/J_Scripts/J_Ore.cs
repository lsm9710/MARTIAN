using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Ore : J_Item
{
    public string itemName;
    public Sprite itmeImage;

    // Start is called before the first frame update
    void Start()
    {
        itemName = "구리";

    }

    // Update is called once per frame
    void Update()
    {
        aaa(itemName, itmeImage);
    }
}
