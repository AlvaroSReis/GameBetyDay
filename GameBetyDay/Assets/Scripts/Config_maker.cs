using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Config_maker : MonoBehaviour
{
    // Start is called before the first frame update
    string config;
    string avatarFid;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener( ()=> { 

            if(File.Exists(Application.persistentDataPath + "/GameBetyDay/AvatarData.json"))
            {
                
                SceneManager.LoadScene("Principal"); 

            }else
            {

                GetComponent<Button>().onClick.AddListener( ()=> { 
                ReturnJson(1,100,1,0);});
            
            }
           
        });

    }

    // Update is called once per frame
    void ReturnJson(int aID, int aHP, int aLvl, int aXP)
    {

        Avatar avatar = new Avatar(aID,aHP,aLvl,aXP);
        config = JsonUtility.ToJson(avatar);
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameBetyDay");
        File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/AvatarData.json", 
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