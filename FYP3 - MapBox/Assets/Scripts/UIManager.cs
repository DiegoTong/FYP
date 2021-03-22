using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool toogleUI;
    public GameObject Dtext;
    int tapCount;
    public Text Coordinates;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Coordinates.text = "Lat: "+ GPS.Instance.latitude.ToString() + "    Lon"+GPS.Instance.longitude.ToString();
        if ((Input.touchCount == 2) && (Input.touches[0].phase == TouchPhase.Began))
        {
           // toogleUI = !toogleUI;
        }
   

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            tapCount += 1;
            StartCoroutine(Countdown());
        }

        if (tapCount == 2)
        {
            tapCount = 0;
            StopCoroutine(Countdown());
            toogleUI = !toogleUI;
        }
        Dtext.SetActive(toogleUI);
    }
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.3f);
        tapCount = 0;
    }
}
