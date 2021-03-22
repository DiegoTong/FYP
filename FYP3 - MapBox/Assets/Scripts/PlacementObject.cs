using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementObject : MonoBehaviour
{
    public bool IsSelected { get; set; }
    public bool matched;
    // Start is called before the first frame update
    void Start()
    {
        matched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (matched == true)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
                
    }
}
