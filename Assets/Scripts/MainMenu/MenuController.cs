using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update


    public void LoadGame()
    {
        GameFlowController.instance.LoadGame();
    }
    public void LoadLvl2() 
    {
        GameFlowController.instance.LoadLvl2();
    }

    public void QuitGame()
    {
        GameFlowController.instance.QuitGame();
    }
}
