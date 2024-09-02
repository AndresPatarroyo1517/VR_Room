using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockController : MonoBehaviour
{
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;

    private const float hoursToDegrees = 360f / 12f;
    private const float minutesToDegrees = 360f / 60f;
    private const float secondsToDegrees = 360f / 60f;

    private void Update()
    {
        DateTime time = DateTime.Now;

        if (hoursTransform != null)
        {
            float hoursAngle = (time.Hour % 12 + time.Minute / 60f) * hoursToDegrees;
            hoursTransform.localRotation = Quaternion.Euler(hoursAngle, 0f, 0f);
        }

        if (minutesTransform != null)
        {
            float minutesAngle = (time.Minute + time.Second / 60f) * minutesToDegrees;
            minutesTransform.localRotation = Quaternion.Euler(minutesAngle, 0f , 0f);
        }

        if (secondsTransform != null)
        {
            float secondsAngle = time.Second * secondsToDegrees;
            secondsTransform.localRotation = Quaternion.Euler(secondsAngle, 0f, 0f);
        }
    }
}