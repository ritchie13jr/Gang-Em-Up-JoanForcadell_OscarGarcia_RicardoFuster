using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryWin : MonoBehaviour
{
   public GameObject VictoryUI;
    public static VictoryWin instance { get { return _instance; } set { _instance = value; }}
    
    private static VictoryWin _instance;

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
        VictoryUI.SetActive(false);
    }
    public void BackToMenu() 
    {
        GameFlowController.instance.LoadMenu();
    }
}
