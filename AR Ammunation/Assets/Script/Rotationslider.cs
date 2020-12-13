using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotationslider : MonoBehaviour
{
    public GameObject rotatingobject;
    public Slider rotatingslider;

    private float previousValue;

    void Awake()
    {
        this.rotatingslider.onValueChanged.AddListener(this.OnSliderChanged);

        this.previousValue = this.rotatingslider.value;
    }

    public void OnSliderChanged(float value)
    {
        float delta = value - this.previousValue;
        this.rotatingobject.transform.Rotate(Vector3.down * delta * 360);
        //this.objectToRotate.transform.Rotate(new Vector3(0 , -delta*360, 0));
        this.previousValue = value;
    }
}
