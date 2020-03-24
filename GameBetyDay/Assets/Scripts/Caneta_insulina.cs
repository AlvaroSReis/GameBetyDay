using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Data;
using Newtonsoft.Json;

public class Caneta_insulina : MonoBehaviour
{

    string objectName;
    string config;
    
    void Start()
    {
        objectName = gameObject.name;
        GetComponent<Button>().onClick.AddListener( ()=> { 
            if(objectName == "Caneta_Red") 
            {
                SceneCall();
                Register(1);
            }else if(objectName == "Caneta_Black")
            {
                SceneCall();
                Register(2);

            }else if(objectName == "Caneta_Blue")
            {
                SceneCall();
                Register(3);

            }else if(objectName == "Caneta_Green")
            {
                SceneCall();
                Register(4);

            }else if(objectName == "Caneta_Yellow")
            {
                SceneCall();
                Register(5);
            }
            });

    }

    IEnumerator SceneCall()
    {
        GameObject.Find("Aplicacao").transform.localScale = new Vector3(1,1,1);
        GameObject.Find("Aplique").transform.localScale = new Vector4(1,1,1);


        yield return new WaitForSeconds(1);

        GameObject.Find("Aplicacao").transform.localScale = new Vector3(0,0,0);
        GameObject.Find("Aplique").transform.localScale = new Vector4(0,0,0);
        
        

    }

    void Register(int objID)
    {

        if(File.Exists(Application.persistentDataPath + "/GameBetyDay/Insulina.json") == false)
        {  

            DataTable table = new DataTable();

            table.Columns.Add("Data");
            table.Columns.Add("Ultra Rapida");
            table.Columns.Add("Regular");
            table.Columns.Add("NPH");
            table.Columns.Add("DETEMIR");
            table.Columns.Add("GLARGINA");
            
            if(objID == 1)
            {
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "1", "0", "0", "0", "0");
            }else if(objID == 2)
            {
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "1", "0", "0", "0");
            }else if(objID == 3)
            {
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "1", "0", "0");
            }else if(objID == 4)
            {
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "1", "0");
            }else if(objID == 5)
            {
                table.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "0", "1");
            }
                
            DataSet dataset = new DataSet("dataSet");
            dataset.Namespace = "NetFrameWork";
            dataset.Tables.Add(table);
            dataset.AcceptChanges();
                
            config = JsonConvert.SerializeObject(dataset);

            File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/Insulina.json", 
            config.ToString());

        }else{

            string json = File.ReadAllText(Application.persistentDataPath + "/GameBetyDay/Insulina.json");

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            string time = System.DateTime.Now.ToString("dd/MM/yyyy");
            int lastRow = dataTable.Rows.Count -1;
            string check = dataTable.Rows[lastRow][0].ToString();
            
            if (check == time)
            {
                if(objID == 1)
                {
                    string val = dataTable.Rows[lastRow][objID].ToString();
                    dataTable.Rows[lastRow][objID] = 
                    (int.Parse(val) + 1).ToString();
                }else if(objID == 2)
                {
                    string val = dataTable.Rows[lastRow][objID].ToString();
                    dataTable.Rows[lastRow][objID] = 
                    (int.Parse(val) + 1).ToString();

                }else if(objID == 3)
                {
                   string val = dataTable.Rows[lastRow][objID].ToString();
                    dataTable.Rows[lastRow][objID] = 
                    (int.Parse(val) + 1).ToString();

                }else if(objID == 4)
                {
                   string val = dataTable.Rows[lastRow][objID].ToString();
                    dataTable.Rows[lastRow][objID] = 
                    (int.Parse(val) + 1).ToString();

                }else if(objID == 5)
                {
                    string val = dataTable.Rows[lastRow][objID].ToString();
                    dataTable.Rows[lastRow][objID] = 
                    (int.Parse(val) + 1).ToString();

                }

            }else if(check != time)
            {

                if(objID == 1)
                {
                    dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "1", "0", "0", "0", "0");
                }else if(objID == 2)
                {
                    dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "1", "0", "0", "0");
                }else if(objID == 3)
                {
                    dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "1", "0", "0");
                }else if(objID == 4)
                {
                    dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "1", "0");
                }else if(objID == 5)
                {
                    dataTable.Rows.Add(System.DateTime.Now.ToString("dd/MM/yyyy"), "0", "0", "0", "0", "1");
                }
                    
                DataSet dataset = new DataSet("dataSet");
                dataset.Namespace = "NetFrameWork";
                dataset.Tables.Add(dataTable);
                dataset.AcceptChanges();
                    
                config = JsonConvert.SerializeObject(dataset);
                
                File.Delete(Application.persistentDataPath + "/GameBetyDay/Insulina.json");
                File.WriteAllText(Application.persistentDataPath + "/GameBetyDay/Insulina.json", 
                config.ToString());

            }
        }
    }
}