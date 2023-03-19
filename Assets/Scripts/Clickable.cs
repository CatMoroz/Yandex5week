using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] AnimationCurve _scaleCurve;
    [SerializeField] float _modelLocalScale = 0.2f;

    [SerializeField] GameObject Prefab;

    private Vector3 _spawnMimiModelPosition;
    private void Awake()
    {
        _spawnMimiModelPosition = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2 + Prefab.gameObject.transform.localScale.y / 2, transform.position.z);
    }
    public void Hit()
    {
        Instantiate(Prefab, _spawnMimiModelPosition, new Quaternion(0,0,0,0));
        StartCoroutine(HitAnimation());
    }
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = _modelLocalScale * Vector3.one * scale;
            yield return null;
        }
        transform.localScale = _modelLocalScale * Vector3.one;
    }
}
