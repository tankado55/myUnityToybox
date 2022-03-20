using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSlider : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if (slider != null) {
            slider.onValueChanged.AddListener(ReactToSlide);
        }

    }

    public void ReactToSlide(float value) {
        Vector3 v = transform.rotation.eulerAngles;
        v.y = 360f * value;
        transform.rotation = Quaternion.Euler(v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
