using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerSpasePlatformer
{ 
    public class MovementController : MonoBehaviour
    {
        internal float _moveInput;

        private void Start()
        {
            Player.Instanse = GetComponent<Player>();
        }

        private void Update()
        {
             _moveInput = Input.GetAxisRaw("Horizontal");
             if (Input.GetKeyDown(KeyCode.Space))
             {
                 Player.Instanse.Jump();
             }
        }
    }
}
