using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class gameOverLogic : MonoBehaviour
{
    public int gaameSceneIndex = 0;
    public void restart()
    {
        
        SceneManager.LoadScene(gaameSceneIndex);
        
        
    }
    public void gameQuit()
    
    {
        gameQuit();
     
    }
}
