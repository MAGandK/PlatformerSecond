using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpasePlatformer;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _countAppleText;
    [SerializeField] private TMP_Text _countEnemyText;
    [SerializeField] private GameObject[] _playerHearts; 
    
    private int _appleCount = 0;
    private int _ememyCount = 0;
    private int _playerHealthCount  = 3;
    private void OnEnable()
    {
        Enemy.OnDieEnemy += EnemyOnDieEnemy;
        Player.OnTakedDamage += PlayerOnTakedDamage;
    }

    private void PlayerOnTakedDamage()
    {
        _playerHealthCount--;
        if (_playerHealthCount >= 0 && _playerHealthCount < _playerHearts.Length)
        {
            _playerHearts[_playerHealthCount].SetActive(false);
        }

    }

    private void EnemyOnDieEnemy()
    {
        _ememyCount ++;
        UpdateCountText();
    }

    private void Start()
    {
        UpdateCountText();
    }

    public void CountAppls()
    {
        _appleCount++;
        UpdateCountText();
    }
   
    private void UpdateCountText()
    {
        _countAppleText.text = _appleCount.ToString();
        _countEnemyText.text = _ememyCount.ToString();
    }
    
    private void OnDisable()
    {
        Enemy.OnDieEnemy -= EnemyOnDieEnemy;
        Player.OnTakedDamage -= PlayerOnTakedDamage;
    }
}
