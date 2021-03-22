using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMenu : MonoBehaviour
{
    public PlacementObject parentMenu;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parentMenu.IsSelected == true)
        {
            menu.gameObject.SetActive(true);
        }
        else if(parentMenu.IsSelected == false)
        {
            menu.gameObject.SetActive(false);
        }
    }
}
