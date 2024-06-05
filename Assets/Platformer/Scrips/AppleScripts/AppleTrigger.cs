using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayerSpasePlatformer;

public class AppleTrigger : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _counter.CountAppls();
        Destroy(this.gameObject);
    }
}
