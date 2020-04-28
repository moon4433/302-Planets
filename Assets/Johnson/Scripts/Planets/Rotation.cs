using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{

    Transform planet;
    Quaternion rotation;
    public float speed;
    float mult = 1;
    public float zRot;

    public Button rwtFour;
    public Button rwtTwo;
    public Button rewind;
    public Button pause;
    public Button play;
    public Button fftTwo;
    public Button fftFour;

    // Start is called before the first frame update
    void Start()
    {
        planet = GetComponent<Transform>();

        rwtFour.onClick.AddListener(RWTFourOnClick);
        rwtTwo.onClick.AddListener(RWTTwoOnClick);
        rewind.onClick.AddListener(RewindOnClick);
        pause.onClick.AddListener(PauseOnClick);
        play.onClick.AddListener(PlayOnClick);
        fftTwo.onClick.AddListener(FFTTwoOnClick);
        fftFour.onClick.AddListener(FFTFourOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation = Quaternion.Euler(1f, ((speed * Time.time) * mult), 1f);
        planet.transform.rotation = Quaternion.Euler(1f, 1f, zRot) * rotation;

    }
    void RWTFourOnClick()
    {
        mult = -4;
    }

    private void FFTFourOnClick()
    {
        mult = 4;
    }

    private void FFTTwoOnClick()
    {
        mult = 2;
    }

    private void PlayOnClick()
    {
        mult = 1;
    }

    private void PauseOnClick()
    {
        mult = 0;
    }

    private void RewindOnClick()
    {
        mult = -1;
    }

    private void RWTTwoOnClick()
    {
        mult = -2;
    }
}
