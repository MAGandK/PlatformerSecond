using System;
using System.Collections.Generic;
using UnityEngine;
using AnimationControll;
using UnityEngine.Serialization;

namespace PlayerSpasePlatformer
{
    public class Player : MonoBehaviour
    {
        public static Player Instanse;
 
        [Header("Movement")]        
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 1f;

        [Header("CillosionInfo")] 
        [SerializeField] private Transform _checkTransform;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayerMask;
        
        internal bool _isGrounded;
        internal bool _isDoubleGround;
        
        private bool _canDoubleJump;
        
        private bool _isMoving;
        private float _velocityY;
        internal bool _isFlip = true;
        
        private Rigidbody2D _rb;
        
        private MovementController _movementController;
        private AnimationController _animationController;

        private int _livesPlayer = 3;
        
        public delegate  void TakedDamage(); 
        public static event TakedDamage OnTakedDamage;
        public delegate  void DiedPlayer(); 
        public static event DiedPlayer OnDiedPlayer;
        
        internal bool _isFinished;
        [SerializeField]private Transform _targetTransform;
        private void Awake()
        {
            if (Instanse == null)
            {
                Instanse = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _movementController = GetComponent<MovementController>();
            _animationController = GetComponent<AnimationController>();
            _rb = GetComponent<Rigidbody2D>();
            _isFinished = false;
        }
        private void Update()
        {
            _isMoving = _rb.velocity.x != 0;
            
           _velocityY = _rb.velocity.y;
           _animationController.Moving(_isMoving, _isGrounded, _velocityY);
            Flip();
            CollisionCheck();
   
        }
        private void FixedUpdate()
        {
            if (_isFinished)
            {
                _rb.velocity = new Vector2(0, _rb.velocity.y); 
                return;
            }
            
            _rb.velocity = new Vector2( _movementController._moveInput * _speed, _rb.velocity.y);
        }
        
        internal void Jump()
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                _canDoubleJump = true; 
            }
            else if (_canDoubleJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                _canDoubleJump = false; 
            }
        }
        
        private void CollisionCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkTransform.position, _groundCheckRadius, _groundLayerMask);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkTransform.position, _groundCheckRadius);
        }

        private void Flip()
        {
            if (_rb.velocity.x > 0 && !_isFlip || _rb.velocity.x < 0 && _isFlip)
            {
                _isFlip = !_isFlip;
                transform.Rotate(0,180,0);
            }
        }

        public void TakeDamade()
        {
            if (_livesPlayer > 0)
            {
                _livesPlayer--;

                if (_livesPlayer <= 0)
                {
                    DiePlayer();
                }
            }
            
            OnTakedDamage?.Invoke();
        }

        private void DiePlayer()
        {
            OnDiedPlayer?.Invoke();
        }
        
        public void SetFinished()
        {
            _isFinished = true;
            _movementController._moveInput = 0;
        }
    }
}
