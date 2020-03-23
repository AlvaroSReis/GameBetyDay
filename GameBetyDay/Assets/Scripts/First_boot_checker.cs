using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class First_boot_checker : MonoBehaviour
{
    // Start is called before the first frame update
    string jsonSavePath;
    void Start()
    {
        
        StartCoroutine(TimeBooter());

    }

    // Update is called once per frame
    void DefaultBoot()
    {

        SceneManager.LoadScene("Principal");
    
    }

    void CharaterCreation()
    {

        SceneManager.LoadScene("Selector_avatar");

    }

    IEnumerator TimeBooter(){

        yield return new WaitForSeconds(1);

        jsonSavePath = Application.persistentDataPath + "/GameBetyDay/AvatarData.json";

        if(File.Exists(jsonSavePath))
        {   
            Debug.Log(jsonSavePath);
            Debug.Log(File.Exists(jsonSavePath));

            DefaultBoot();

        }else
        {

            CharaterCreation();

        }


    }

}
