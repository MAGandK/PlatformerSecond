using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpasePlatformer;
using UnityEngine;

public class TriggerFinish : MonoBehaviour
{
    private Animator _animatorTrigger;

    private void Start()
    {
        _animatorTrigger = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player controller))
        {
            controller.SetFinished();
            Debug.Log("Finish");

            _animatorTrigger.SetBool("isFinish", true);
   
        }
    }
}
