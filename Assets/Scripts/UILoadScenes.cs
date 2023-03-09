using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class UILoadScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadAppart1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAppart2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFastFood()
    {
        SceneManager.LoadScene(3);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
