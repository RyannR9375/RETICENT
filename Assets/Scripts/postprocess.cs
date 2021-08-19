using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postprocess : MonoBehaviour
{

    public PostProcessVolume postprocessvolume;
    public HealthBar healthbar;

    public float intensityMin = 0.6f;
    public float intensityMax = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            //postprocessvolume.weight = Mathf.Sin(Time.time) * 0.5f + 0.5f;
            postprocessvolume.weight = (1 - healthbar.GetHealthNormalized()) * (intensityMax - intensityMin) + intensityMin;
        }
    }
}
