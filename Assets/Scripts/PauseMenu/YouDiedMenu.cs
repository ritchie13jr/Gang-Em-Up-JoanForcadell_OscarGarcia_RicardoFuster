using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedMenu : MonoBehaviour
{
   public GameObject YouDiedUI;
    public static YouDiedMenu instance { get { return _instance; } set { _instance = value; }}
    
    private static YouDiedMenu _instance;

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
        YouDiedUI.SetActive(false);
    }
    public void Retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex)
    }
}
