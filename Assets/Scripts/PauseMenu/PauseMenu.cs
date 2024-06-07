using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public static PauseMenu instance { get { return _instance; } set { _instance = value; }}
    
    private static PauseMenu _instance;

    void Awake() 
    {
       if (instance != null) 
       {
        Destroy(gameObject);
       } 
       else 
       {
        instance = this;
        DontDestroyOnLoad(gameObject);
       }
    }
    void Start() 
    {
        PauseMenuUI.SetActive(false);
    }
    public void Resume() 
    {
        GameFlowController.instance.Resume();
    }
    public void LoadMenu() 
    {
        GameFlowController.instance.LoadMenu();
    }
    public void QuitGame() 
    {
        GameFlowController.instance.QuitGame();
    }
}