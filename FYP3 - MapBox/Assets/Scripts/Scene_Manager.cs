using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    public Text LoadMap_MainSceneText;
    public Button resetButton;
    public Button loadScenesButton;
    private static Scene_Manager _instance;

    public static Scene_Manager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            LoadMap_MainSceneText.text = "Load Map";
        }
        else if (SceneManager.GetActiveScene().name == "FullMap" || SceneManager.GetActiveScene().name == "Mini_Game_1")
        {
            LoadMap_MainSceneText.text = "Load Main Scene";
        }
    }
    public void loadNextScene()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("Mini_Game_1");
        }
        else if (SceneManager.GetActiveScene().name == "FullMap" || SceneManager.GetActiveScene().name == "Mini_Game_1")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (resetButton.gameObject.activeSelf)
        {
            resetButton.gameObject.SetActive(false);
        }

        if (loadScenesButton.gameObject.activeSelf)
        {
            loadScenesButton.gameObject.SetActive(false);
        }
    }
    public void ResetScene()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void showButtons()
    {
        if(resetButton.gameObject.activeSelf)
        {
            resetButton.gameObject.SetActive(false);
        }
        else
        {
            resetButton.gameObject.SetActive(true);
        }


        if(loadScenesButton.gameObject.activeSelf)
        {
            loadScenesButton.gameObject.SetActive(false);
        }
        else
        {
            loadScenesButton.gameObject.SetActive(true);
        }
    }
}
