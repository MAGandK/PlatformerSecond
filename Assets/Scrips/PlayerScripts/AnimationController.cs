using System;
using UnityEngine;

namespace AnimationControll
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animatorPlayer;
        private void Start()
        {
            _animatorPlayer = GetComponent<Animator>();
        }

        public void Moving(bool isMoving, bool isGrounded, float velocityY) 
        {
            _animatorPlayer.SetBool("isMove", isMoving);
            _animatorPlayer.SetBool("isGrounded", isGrounded );
            _animatorPlayer.SetFloat("velocityY", velocityY);
            
        }
    }
}
