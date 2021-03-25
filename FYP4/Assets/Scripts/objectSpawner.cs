using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class objectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public PlacementObject[] placedObjects;
    public Color activeColor = Color.red;
    public Color inactiveColor = Color.green;
    public Camera arCamera;
    public Vector2 touchPosition = default;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    PlacementObject currentObj;
    // Start is called before the first frame update
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    public string loc;
    // Start is called before the first frame update
    void Awake()
    {
        ChangeSelectObject(placedObjects[0]);
        currentObj = placedObjects[0];
        loc = currentObj.tag;
    }
    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectObjOnTouch();
        //placeObjOnTouch();
    }

    void SelectObjOnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            touchPosition = t.position;
            if (t.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(t.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
            
                    PlacementObject placementObj = hitObject.transform.GetComponent<PlacementObject>();
                    if (placementObj != null)
                    {
                        ChangeSelectObject(placementObj);
                        currentObj = placementObj;
                        loc = currentObj.tag;
                    }
                }
            }
        }
    }
    void placeObjOnTouch()
    {
        if ((Input.touchCount == 1) && (Input.touches[0].phase == TouchPhase.Began))
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }
    void ChangeSelectObject(PlacementObject selected)
    {
        foreach (PlacementObject current in placedObjects)
        {
            MeshRenderer heshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
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
