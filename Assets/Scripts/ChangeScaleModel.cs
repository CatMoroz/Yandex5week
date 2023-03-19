using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleModel : MonoBehaviour
{
    private Vector3 _defaultLocalScale;
    [SerializeField] int ScaleIncreasingCoefficient = 3;
    private void Awake()
    {
        _defaultLocalScale = transform.localScale;
    }
    public void ChangeScaleFromSlider(float value)
    {
        transform.localScale =_defaultLocalScale + ScaleIncreasingCoefficient*Vector3.one * value;
    }
}
