using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_pe_diabetico : MonoBehaviour
{
    
	void Start () 
    {

      GetComponent<Button>().onClick.AddListener( ()=> { SceneManager.LoadScene("Pe_diabetico"); });
	
    }

}
