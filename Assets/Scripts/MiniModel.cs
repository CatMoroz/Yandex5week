using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniModel : MonoBehaviour
{
    [SerializeField] GameObject CollectEffectPrefab;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(0, 100), Random.Range(150, 200), Random.Range(-100, 0)));
    }
    public void Collect()
    {
        Vector3 SpawnPosition = transform.position;
        Quaternion CoinEffectRotation = new Quaternion();
        CoinEffectRotation.SetEulerRotation(0, -45f, 0);
        Instantiate(CollectEffectPrefab, SpawnPosition, CoinEffectRotation);
        Destroy(gameObject);
    }
}
