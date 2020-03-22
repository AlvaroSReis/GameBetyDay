using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_bety : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mAvatar;
    GameObject fAvatar;
    void Start()
    {
       GetComponent<Button>().onClick.AddListener( ()=> 
        {   

            GameObject.Find("Avatar_F_Full").transform.localScale = new Vector3(1,1,1);

            GameObject.Find("Avatar_M_Full").transform.localScale = new Vector4(0,0,0); 

        });; 
    }

    // Update is called once per frame

}
