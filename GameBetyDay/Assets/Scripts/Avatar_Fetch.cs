using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Data;

public class Avatar_Fetch : MonoBehaviour
{
    // Start is called before the first frame update

    Avatar avatar;
    string config;
    DataTable table;

    void Start()
    {
        
        if(File.Exists(Application.persistentDataPath + "/GameBetyDay/AvatarData.json")== false)
        {
            Avatar avatar = new Avatar(1,100,1,0);
            config = JsonUtility.ToJson(avatar);
            System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameBetyDay");
            File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/AvatarData.json", 
            config.ToString());
            Debug.Log("Running1");

        }if(File.Exists(Application.persistentDataPath + "/GameBetyDay/Data.json") == false){

            table = new DataTable();
            table.Columns.Add("Data");
            table.Columns.Add("Exercicio");
            table.Columns.Add("Alimentacao");

            DataRow row = table.NewRow();
            table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), 0, 0);
            config = JsonUtility.ToJson(table);
            File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/Data.json", 
            config.ToString());
            Debug.Log("Running2");

        }

        using (StreamReader stream = new StreamReader(Application.persistentDataPath + "/GameBetyDay/AvatarData.json")){
            string jsonData = stream.ReadToEnd();
            avatar = JsonUtility.FromJson<Avatar>(jsonData);
            Debug.Log(avatar);
        }
        
        if(avatar.avatarID == 1){
            GameObject.Find("Avatar_M_Full").transform.localScale = new Vector3(1,1,1);
            GameObject.Find("Avatar_F_Full").transform.localScale = new Vector4(0,0,0);
        }else{
            GameObject.Find("Avatar_F_Full").transform.localScale = new Vector3(1,1,1);
            GameObject.Find("Avatar_M_Full").transform.localScale = new Vector4(0,0,0);
        }

    }
}

