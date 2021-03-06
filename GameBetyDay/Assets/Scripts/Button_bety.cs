﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Button_bety : MonoBehaviour
{
    // Start is called before the first frame update
    string config;

    void Start()
    {
       GetComponent<Button>().onClick.AddListener( ()=> 
        {   

            GameObject.Find("Avatar_F_Full").transform.localScale = new Vector3(1,1,1);
            GameObject.Find("Avatar_M_Full").transform.localScale = new Vector4(0,0,0);
            ReturnJson(2,100,1,0);

        });; 

    }

    void ReturnJson(int aID, int aHP, int aLvl, int aXP)
    {
        Avatar avatar = new Avatar(aID,aHP,aLvl,aXP);
        config = JsonUtility.ToJson(avatar);
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameBetyDay");
        File.Delete(Application.persistentDataPath + "/GameBetyDay/AvatarData.json");
        File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/AvatarData.json", 
        config.ToString());
    }

}
