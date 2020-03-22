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
        
        StartCoroutine(ExampleCoroutine());

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

    IEnumerator ExampleCoroutine(){

        yield return new WaitForSeconds(1);

        jsonSavePath = Application.persistentDataPath + "/saveload.json";

        if(File.Exists(jsonSavePath)){
            
            

            DefaultBoot();

        }else{

            CharaterCreation();

        }


    }

}
