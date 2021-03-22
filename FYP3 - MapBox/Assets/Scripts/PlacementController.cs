using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class PlacementController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlacementObject[] placedObjects;
    public Color activeColor = Color.red;
    public Color inactiveColor = Color.green;
    public Camera arCamera;
    public Vector2 touchPosition = default;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    PlacementObject currentObj;
    void Awake()
    {
        ChangeSelectObject(placedObjects[0]);
        currentObj = placedObjects[0];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount >0)
        {
            Touch t = Input.GetTouch(0);
            touchPosition = t.position;
            if(t.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(t.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    PlacementObject placementObj = hitObject.transform.GetComponent<PlacementObject>();
                    if (placementObj != null)
                    {
                        if(currentObj.tag == placementObj.tag)
                        {
                            currentObj.matched = true;
                            placementObj.matched = true;
                        }
                        ChangeSelectObject(placementObj);
                        currentObj = placementObj;
                    }
                }
            }
        }
    }
    void ChangeSelectObject(PlacementObject selected)
    {
        foreach(PlacementObject current in placedObjects)
        {
            MeshRenderer heshRenderer = current.GetComponent<MeshRenderer>();
            if(selected != current)
            {
                current.IsSelected = false;
                heshRenderer.material.color = inactiveColor;
            }
            else
            {
                current.IsSelected = true;
                heshRenderer.material.color = activeColor;
            }
        }
    }
}
