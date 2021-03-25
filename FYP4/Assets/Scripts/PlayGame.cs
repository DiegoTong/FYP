using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : EnableMenu
{
    public GameObject instructions;
    public GPS gpsCode;
    // Start is called before the first frame update
    void Start()
    {
        gpsCode = GameObject.Find("SceneManager").GetComponent<GPS>();
    }

    // Update is called once per frame
    void Update()
    {
        if(parentMenu.IsSelected == true)
        {
            if (gpsCode.chooseGame == true)
            {
                instructions.SetActive(false);
                menu.gameObject.SetActive(true);
            }
            else
            {
                instructions.SetActive(true);
                menu.gameObject.SetActive(false);
            }
            StartCoroutine(wait());
        }
        else
        {
            instructions.SetActive(false);
            menu.gameObject.SetActive(false);
        }
   

    }
    IEnumerator wait()
    {

        yield return new WaitForSeconds(4);
        if (gpsCode.chooseGame == true)
        {
            SceneManager.LoadScene("Mini_Game_1");
        }
        else
        {
            SceneManager.LoadScene("Mini_Game_2");
        }
    }
}
