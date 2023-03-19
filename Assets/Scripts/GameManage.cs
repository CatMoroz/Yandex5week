using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManage : MonoBehaviour
{
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Coins;
    [SerializeField] List<GameObject> GameObjectsThanPausedGame = new List<GameObject>();

    private RaycastHit _raycastHit;
    private bool _isGameActive;
    private int _coinsCount;
    private void Update()
    {
        Coins.SetText(_coinsCount.ToString());
        _isGameActive = true;
        for (int i = 0; i < GameObjectsThanPausedGame.Count; i++)
        {
            if (GameObjectsThanPausedGame[i].active)
            {
                _isGameActive = false;
            }
        }
        if (_isGameActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _raycastHit))
            {
                if (_raycastHit.collider.gameObject.TryGetComponent(out Clickable _clickable))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        _clickable.Hit();
                    }
                }
                if (_raycastHit.collider.gameObject.TryGetComponent(out MiniModel _minimodel))
                {
                    _coinsCount += 1;
                    _minimodel.Collect();
                }
            }
        }
    }
    public void SetName(string name)
    {
        Name.text = name;
    }
}
