using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{

    public Transform orbitCenter;
    public LineRenderer orbitPath;
    public Vector3 offset;
    public Vector3 radialCirc;
    Quaternion rotation;
    public float zRot;
    public float xRot;
    Transform planet;
    public float speed;
    float mult = 1;


    [Range(1, 120)] public float radius = 6;
    [Range(4, 128)] public int resolution = 8;

    public Button rwtFour;
    public Button rwtTwo;
    public Button rewind;
    public Button pause;
    public Button play;
    public Button fftTwo;
    public Button fftFour;

    void Start()
    {
        planet = GetComponent<Transform>();
        orbitPath = GetComponent<LineRenderer>();
        orbitPath.loop = true;

        rwtFour.onClick.AddListener(RWTFourOnClick);
        rwtTwo.onClick.AddListener(RWTTwoOnClick);
        rewind.onClick.AddListener(RewindOnClick);
        pause.onClick.AddListener(PauseOnClick);
        play.onClick.AddListener(PlayOnClick);
        fftTwo.onClick.AddListener(FFTTwoOnClick);
        fftFour.onClick.AddListener(FFTFourOnClick);
    }

    void Update()
    {

        rotation = Quaternion.Euler(1f, ((speed * Time.time) * mult), 1f);
        planet.transform.rotation = Quaternion.Euler(xRot, 1f, zRot) * rotation;

        Vector3 pos = FindOrbitPoint(((mult * Time.time) * speed), radius);

        transform.position = pos;
        UpdatePoints();
    }

    private Vector3 FindOrbitPoint(float angle, float mag)
    {

        Vector3 pos = (orbitCenter == null) ? Vector3.zero : (orbitCenter.position + offset);

        pos.x += Mathf.Cos(angle) * (mag + radialCirc.x);
        pos.z += Mathf.Sin(angle) * (mag + radialCirc.z);
        return pos;
    }

    /// <summary>
    /// Set the points in the LineRenderer
    /// </summary>
    void UpdatePoints()
    {
        //make an array to hold the points of the rotation path
        Vector3[] points = new Vector3[resolution];

        //for loop to fill the array with the orbit path locations
        for(int i=0; i < points.Length; i++)
        {
            float p = i / (float)points.Length;

            float radians = p * Mathf.PI * 2;

            points[i] = FindOrbitPoint(radians, radius);
        }

        orbitPath.positionCount = resolution;
        orbitPath.SetPositions(points);
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
