using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_registro_dados : MonoBehaviour
{

	void Start () 
    {

      GetComponent<Button>().onClick.AddListener( ()=> { SceneManager.LoadScene("Registro_dados"); });
	
    }

}
