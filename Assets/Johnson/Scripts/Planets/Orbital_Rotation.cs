using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital_Rotation : MonoBehaviour
{

    public Transform orbitalPoint;
    Transform planet;
    Vector3 a;
    public int orbitX = 10 ;
    public int orbitY = 10 ;

    // Start is called before the first frame update
    void Start()
    {
        planet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        attemptOne();
    }

    void attemptOne()
    {
        
        a.x = orbitX * Mathf.Cos(Time.deltaTime);
        a.z = orbitY * Mathf.Sin(Time.deltaTime);

        float magB = Mathf.Sqrt(a.x * a.x + a.z * a.z);
        float radB = Mathf.Atan2(a.z, a.x) - Mathf.Rad2Deg;

        a.x = magB * Mathf.Cos(radB);
        a.z = magB * Mathf.Sin(radB);
        planet.position = new Vector3(a.x, 0, a.z);

    }
}
