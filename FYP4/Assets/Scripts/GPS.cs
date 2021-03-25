using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public Text gpsOut;
    public bool isUpdating;
    public GameObject spawnObject;
    public bool chooseGame;
    private void Update()
    {
        if (!isUpdating)
        {
            StartCoroutine(GetLocation());
            isUpdating = !isUpdating;
        }
    }
    IEnumerator GetLocation()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait <1)
        {
            gpsOut.text = "Timed out";
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsOut.text = "Unable to determine device location";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            gpsOut.text = "Lat: " + Input.location.lastData.latitude + "    Lon" + Input.location.lastData.longitude;
           // gpsOut.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + 100f + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
        if((Input.location.lastData.longitude <= -7.8286f && Input.location.lastData.longitude <= -7.8224f) && (Input.location.lastData.latitude <= 52.6814f && Input.location.lastData.latitude <= 52.6829f))
        {
            chooseGame = true;
            //spawnObject.SetActive(true);
        }
        else 
        {
            chooseGame = false;
            //spawnObject.SetActive(true);
        }
        // Stop service if there is no need to query location updates continuously
        isUpdating = !isUpdating;
        Input.location.Stop();
    }

    /*
    public static GPS Instance { set; get; }
    public float latitude;
    public float longitude;
    public Text Coordinates;
    // Start is called before the first frame update
    private void Awake()

    {

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))

        {

            Permission.RequestUserPermission(Permission.FineLocation);

        }

    }
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());

    }
    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait >0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if(maxWait <=0)
        {
            Debug.Log("Time out");
            yield break;
        }
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        //    while (true)
        //   {
        //  latitude = Input.location.lastData.latitude;
        // longitude = Input.location.lastData.longitude;
        //Coordinates.text = "Lat: " + latitude + "    Lon" + longitude;
        //   yield return new WaitForSeconds(10);
        // }
        Input.location.Stop();
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        Coordinates.text = "Lat: " + latitude + "    Lon" + longitude;
    }
   */
}
