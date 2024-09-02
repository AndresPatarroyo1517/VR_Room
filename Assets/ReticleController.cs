using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleEffects : MonoBehaviour
{
    public float scaleSpeed = 1f;
    public float maxScale = 1.5f;   
    public float minScale = 0.5f; 

    private bool scalingUp = true;

    void Update()
    {
        Vector3 scale = transform.localScale;

        if (scalingUp)
        {
            scale += Vector3.one * scaleSpeed * Time.deltaTime;
            if (scale.x >= maxScale)
            {
                scale = new Vector3(maxScale, maxScale, maxScale);
                scalingUp = false;
            }
        }
        else
        {
            scale -= Vector3.one * scaleSpeed * Time.deltaTime;
            if (scale.x <= minScale)
            {
                scale = new Vector3(minScale, minScale, minScale);
                scalingUp = true;
            }
        }

        transform.localScale = scale;
    }
}
