using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class removeScene : MonoBehaviour
{
   
    // Start is called before the first frame update
    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }

   /* public void NextScene()
    {
        SceneManager.LoadScene(1);
    }*/

}
