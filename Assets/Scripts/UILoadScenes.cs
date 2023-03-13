using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class UILoadScenes : MonoBehaviour
{
    public Animator transtion;
    public float transitionTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadAppart1()
    {
        StartCoroutine(LoadAppart1_1());
    }

    IEnumerator LoadAppart1_1()
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }

    public void LoadAppart2()
    {
        StartCoroutine(LoadAppart2_1());
    }

    IEnumerator LoadAppart2_1()
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(2);
    }

    public void LoadFastFood()
    {
        StartCoroutine(LoadFastFood_1());
    }

    IEnumerator LoadFastFood_1()
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
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
