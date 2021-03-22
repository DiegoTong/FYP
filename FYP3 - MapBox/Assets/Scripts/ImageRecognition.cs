using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class ImageRecognition : MonoBehaviour
{
    public GameObject testobj;
    private ARTrackedImageManager arTrackedImManager;
    // Start is called before the first frame update
     void Awake()
    {
        arTrackedImManager = FindObjectOfType<ARTrackedImageManager>();
    }
    void Start()
    {
        arTrackedImManager.trackedImagesChanged += OnImageChanged;   
    }
    public void OnDisabled()
    {
        arTrackedImManager.trackedImagesChanged -= OnImageChanged;
    }
    public void OnImageChanged(ARTrackedImagesChangedEventArgs arg)
    {
        foreach(var trackedImage in arg.added)
        {
            if (trackedImage.name == "keyboard")
            {

            }
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
