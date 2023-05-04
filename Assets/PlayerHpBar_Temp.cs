using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar_Temp : MonoBehaviour
{
    [SerializeField]
    GameObject _hpBar;
    [SerializeField]
    GameObject _localHpBar;
    [SerializeField]
    GameObject _canvas;
    [SerializeField]
    Vector3 _hpBarOffset;
    Scrollbar _scrollbar;
    //_Player _player;



    // Start is called before the first frame update
    void Start()
    {
       // _player = GetComponent<_Player>();
        _localHpBar = Instantiate(_hpBar);
        _scrollbar = _localHpBar.GetComponent<Scrollbar>();
        _localHpBar.transform.parent = _canvas.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _localHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + _hpBarOffset);
        //_scrollbar.size = _player.CurrentHp/_player.MaxHp;
    }
}
