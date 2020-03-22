using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_selector : MonoBehaviour
{
    

    void Start()
    {
        
        GameObject.Find("Avatar_F_Full").transform.localScale = new Vector3(0,0,0);
        GameObject.Find("Avatar_M_Full").transform.localScale = new Vector3(1,1,1);

    }

}
