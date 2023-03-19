using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChanger : MonoBehaviour
{
    [SerializeField] GameObject[] ModelVariantArray = new GameObject[6];
    [SerializeField] Renderer[] ModelVariantRendererArray = new Renderer[6];

    private int _nowModelNumberInArray = 0;
    private void Awake()
    {
        ChangeModelMaterial(ModelVariantRendererArray[_nowModelNumberInArray].material);
    }

    public void ChangeModelMash(int value)
    {
        ModelVariantArray[_nowModelNumberInArray].SetActive(false);
        _nowModelNumberInArray = value;
        ModelVariantArray[value].SetActive(true);
    }
    public void ChangeModelMaterial(Material material)
    {
        for (int i = 0; i < ModelVariantRendererArray.Length / 2; i++)
        {
            ModelVariantRendererArray[i].material = material;
            ModelVariantRendererArray[i+3].material = material;
        }
    }
}
