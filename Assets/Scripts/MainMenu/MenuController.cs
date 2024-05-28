using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public static MenuController Instance = null;
   GameObject optionsMenu;
   GameObject exitPanel;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }   

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void LoadLvl2() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
