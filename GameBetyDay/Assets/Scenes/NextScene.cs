using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

   void Update(){
      if(Input.GetMouseButtonDown(0))
      {
         GoNextScene();
      }

   }
   public void GoNextScene(){
	   
	   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
    
}
