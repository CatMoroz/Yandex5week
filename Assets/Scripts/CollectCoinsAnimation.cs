using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoinsAnimation : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Destroying());
    }
    private void Update()
    {
        transform.position+= Vector3.up * Time.deltaTime;
    }

    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
