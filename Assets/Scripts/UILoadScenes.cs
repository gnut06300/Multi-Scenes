using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using System.IO;


public class UILoadScenes : MonoBehaviour
{
    public Animator transtion;
    public GameObject menu;
    public float transitionTime = 1.5f;
    private bool active = false;
    [SerializeField] GameObject player;
    [SerializeField] Data data;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            menu.SetActive(active);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                if (!active)
                {
                    active = true;
                    menu.SetActive(active);
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    active = false;
                    menu.SetActive(active);
                    Cursor.lockState = CursorLockMode.Locked;
                }

            }
        }
        data.position = player.transform.position;
        data.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(LoadScene(index));
    }
    
    IEnumerator LoadScene(int index)
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }

    IEnumerator LoadSceneLoad(int index, Vector3 positionSave)
    {
        transtion.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
        
    }

    [System.Serializable]
    public class SaveData
    {
        public Vector3 position;
        public int sectionIndex;
    }

    public void SaveDataFile()
    {
        SaveData saveData = new SaveData();
        saveData.position = data.position;
        saveData.sectionIndex = data.sceneIndex;
        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            if(saveData.sectionIndex == SceneManager.GetActiveScene().buildIndex)
            {
                player.GetComponent<CharacterController>().Move(saveData.position - player.transform.position);
            }
            else
            {
                StartCoroutine(LoadSceneLoad(saveData.sectionIndex, saveData.position));
            }
            
        }
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
