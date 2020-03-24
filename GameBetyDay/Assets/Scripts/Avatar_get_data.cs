using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Data;
using System.Text;
using Newtonsoft.Json;

public class Avatar_get_data : MonoBehaviour
{

    Avatar avatar;
    string config;
    DataTable table;

    //Verifica se todos os arquivos de configuração do jogo existem
    void Start()
    {
        try{

            if(File.Exists(Application.persistentDataPath + "/GameBetyDay/AvatarData.json")== false)
            {
                Avatar avatar = new Avatar(1,100,1,0);
                config = JsonUtility.ToJson(avatar);
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/GameBetyDay");
                File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/AvatarData.json", 
                config.ToString());

            }if(File.Exists(Application.persistentDataPath + "/GameBetyDay/Data.json") )
            {  

                DataTable table = new DataTable();

                table.Columns.Add("Data");
                table.Columns.Add("Exercicio");
                table.Columns.Add("Alimentacao");
                table.Columns.Add("Aplicar Insulina");
                table.Columns.Add("Tratar Pe Diabetico");
            
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "0");
                
                DataSet dataset = new DataSet("dataSet");
                dataset.Namespace = "NetFrameWork";
                dataset.Tables.Add(table);
                dataset.AcceptChanges();
                
                config = JsonConvert.SerializeObject(dataset);

                File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/Data.json", 
                config.ToString());

            }

            
            using (StreamReader stream = new StreamReader(Application.persistentDataPath + "/GameBetyDay/AvatarData.json")){
                string jsonData = stream.ReadToEnd();
                avatar = JsonUtility.FromJson<Avatar>(jsonData);
            }
            
            if(avatar.avatarID == 1){
                GameObject.Find("Avatar_M_Full").transform.localScale = new Vector3(1,1,1);
                GameObject.Find("Avatar_F_Full").transform.localScale = new Vector4(0,0,0);
            }else{
                GameObject.Find("Avatar_F_Full").transform.localScale = new Vector3(1,1,1);
                GameObject.Find("Avatar_M_Full").transform.localScale = new Vector4(0,0,0);
            }

        }catch{
            
        }
        
    }
    public string DataTableToJSONWithJSONNet(DataTable table) {  
        string JSONString=string.Empty;  
        JSONString = JsonConvert.SerializeObject(table, Formatting.Indented);  
        return JSONString;    
    }
}



/*
public class TableToJson{
    public string DataTableToJSONWithStringBuilder(DataTable table)   
    {  
        var JSONString = new StringBuilder();  
        if (table.Rows.Count > 0)   
        {  
            JSONString.Append("[");  
            for (int i = 0; i < table.Rows.Count; i++)   
            {  
                JSONString.Append("{");  
                for (int j = 0; j < table.Columns.Count; j++)   
                {  
                    if (j < table.Columns.Count - 1)   
                    {  
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");  
                    }   
                    else if (j == table.Columns.Count - 1)   
                    {  
                        JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");  
                    }  
                }  
                if (i == table.Rows.Count - 1)   
                {  
                    JSONString.Append("}");  
                }   
                else   
                {  
                    JSONString.Append("},");  
                }  
            }  
            JSONString.Append("]");  
        }  
        return JSONString.ToString();  
    } 
}
*/