using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGetSpeed : MonoBehaviour
{
    public float speed;
    public Text MeterPerSecond, KilometerPerHour, KilometerPerSecond;

    void Update()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        MeterPerSecond.text = string.Format("{0:00.00} m/s", speed);
        KilometerPerHour.text = string.Format("{0:00.00} km/h", speed * 3.6f);
        KilometerPerSecond.text = string.Format("{0:00.00} km/s", speed * 0.001f);
    }
}