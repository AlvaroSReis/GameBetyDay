using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AvatarDisabler : MonoBehaviour
{   
    string jsonSavePath;
    // Start is called before the first frame update
    void Start()
    {
         jsonSavePath = Application.persistentDataPath + "/saveload.json";
        //SceneDelete(scene);
    }

    // Update is called once per frame
    void SceneDelete(string scene)
    {
        if(scene == "Principal"){
             Destroy(gameObject);
        }
    }
}
