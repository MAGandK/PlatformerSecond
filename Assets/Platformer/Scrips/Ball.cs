using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpasePlatformer;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _ballSpeed = 10f;
    
    private Rigidbody2D _rbBall;


    private ShootingPlayer _shooting;
    private void Start()
    {
        _rbBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
          FlipBullet();
    }

    public void FlipBullet()
    {
        if (Player.Instanse._isFlip)
        {
            _rbBall.velocity = Vector2.right * _ballSpeed;
        }
        else
        {
            _rbBall.velocity = Vector2.left * _ballSpeed;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<Enemy>().DiedEnemy(); 
            gameObject.SetActive(false); 
            Debug.Log("Удар с Enemy");
            
        }
        else if (collider.gameObject.CompareTag("Level"))
        {
            collider.gameObject.GetComponent<Collider2D>();
            gameObject.SetActive(false); 
            Debug.Log("Удар с уровнем");
        }
    }
}
