using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Config_maker : MonoBehaviour
{
    // Start is called before the first frame update
    string config;

    void Start()
    {
        ReturnJson();
    }

    // Update is called once per frame
    void ReturnJson()
    {
        Avatar avatar = new Avatar(1,100,1,0);
        config = JsonUtility.ToJson(avatar);
        System.IO.Directory.CreateDirectory(Application.dataPath + "/config");
        File.WriteAllText(Application.dataPath + "/config/AvatarData.json", 
        config.ToString());
    }
}

[System.Serializable]
public class Avatar{

    public int avatarID;
    public int avatarHP;
    public int avatarLevel;
    public int avatarXP;

    public Avatar(int ID, int HP, int Level, int XP) 
    {
    
        avatarID = ID;
        avatarHP = HP;
        avatarLevel = Level;
        avatarXP = XP;

    }
}