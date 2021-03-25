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
    public Button respawnBall;
    public Button googleMapsButton;
    public static Scene_Manager Instance { get { return _instance; } }
    public objectSpawner objectspawner;
    public Text test;
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
        if(SceneManager.GetActiveScene().name == "Mini_Game_2")
        {
            respawnBall.gameObject.SetActive(true);
        }
        else
        {
            respawnBall.gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            googleMapsButton.gameObject.SetActive(true);
        }
        else
        {
            googleMapsButton.gameObject.SetActive(false);
        }
        test.text = objectspawner.loc;
    }
    public void loadNextScene()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("FullMap");
        }
        else if (SceneManager.GetActiveScene().name == "FullMap" || SceneManager.GetActiveScene().name == "Mini_Game_1"|| SceneManager.GetActiveScene().name == "Mini_Game_2")
        {
            SceneManager.LoadScene("SampleScene");
            objectspawner = GameObject.Find("plc").GetComponent<objectSpawner>();
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
    public void GotoGoogleMaps()
    {
        if(objectspawner.loc == "stadium")
        {
            Application.OpenURL("http://maps.google.com/maps?q=52.6811,-7.8256");
        }
        else if(objectspawner.loc == "hotel")
        {
            Application.OpenURL("http://maps.google.com/maps?q=52.67941975,-7.81212242");
        }
        else if (objectspawner.loc == "church")
        {
            Application.OpenURL("http://maps.google.com/maps?q=52.68024735,-7.809072");
        }
        else
        {
            Application.OpenURL("http://maps.google.com/maps?q=52.67874,-7.81428");
        }
    }
}
