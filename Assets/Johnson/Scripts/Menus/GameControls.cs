using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{

    Camera mainCam;

    public Canvas gameMenu;
    public Button mercury;
    public Button venus;
    public Button earth;
    public Button mars;
    public Button jupiter;
    public Button saturn;
    public Button uranus;
    public Button neptune;
    public Button freeRoam;
    
    public Transform planetMerc;

    public Vector3 camOffset;

    bool followMerc = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();

        mercury.onClick.AddListener(MercuryOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (followMerc)
        {
            planetMerc.position += camOffset;
            mainCam.transform.position = (planetMerc.position);
        }
    }

    void MercuryOnClick()
    {
        followMerc = true;
    }
}
