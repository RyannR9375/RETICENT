using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postprocess : MonoBehaviour
{

    public PostProcessVolume postprocessvolume;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            postprocessvolume.weight = Mathf.Sin(Time.time) * 0.5f + 0.5f;
        }
    }
}
