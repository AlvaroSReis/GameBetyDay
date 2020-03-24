using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using Newtonsoft.Json;

public class Avatar_status_checker : MonoBehaviour
{
    string config;
    void Start()
    {
        
        InvokeRepeating("Status", 1.0f, 0.5f);

    }
    void Status()
    {
        
        string json = File.ReadAllText(Application.persistentDataPath + "/GameBetyDay/Data.json");

        DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

        DataTable dataTable = dataSet.Tables["Table1"];

        string time = System.DateTime.Now.ToString("dd/MM/yyyy");
        int lastRow = dataTable.Rows.Count -1;
        string check = dataTable.Rows[lastRow][0].ToString();
        Debug.Log(dataTable.Rows[lastRow][0].ToString());

        if(check != time)
        {
            
            dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "0");
                
            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            dataset.Tables.Add(dataTable);
            dataset.AcceptChanges();
                
            config = JsonConvert.SerializeObject(dataset);

            File.Delete(Application.persistentDataPath + "/GameBetyDay/Data.json");
            File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/Data.json", 
            config.ToString());

        }

    }


}
