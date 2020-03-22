using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists("Avatar.json")){
            //go to main scene
        }else{
            //go to make avatar scene
        }
        
        if(File.Exists("Data.json")){
            //go to main scene
        }else{
            //ask to import or make new
        }

    }
}
