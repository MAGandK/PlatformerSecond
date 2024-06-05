using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _enemySpeed = 1f;
    [SerializeField] private Vector3 _targetPositionEnemy;
    private Vector3 _startPositionEnemy;

    private bool _isFlip = true;
    private Rigidbody2D _rb;
    
    public delegate void Dead();
    public static event  Dead OnDieEnemy;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPositionEnemy = gameObject.transform.position;
    }

    private void Update()
    { 
        MovementEnemy();
    }

    private void MovementEnemy()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
            _targetPositionEnemy,_enemySpeed * Time.deltaTime);

        if (gameObject.transform.position == _targetPositionEnemy)
        {
            FlipEnemy();
        }
    }

    private void FlipEnemy()
    {
            _isFlip = !_isFlip;
            transform.Rotate(0, 180, 0);
            SwitchTargetPosition();
    }

    private void SwitchTargetPosition()
    {
        Vector3 tempPosition = _startPositionEnemy;
        _startPositionEnemy = _targetPositionEnemy;
        _targetPositionEnemy = tempPosition;
    }

   public void DiedEnemy()
    {
        gameObject.SetActive(false);
        OnDieEnemy?.Invoke();
    }
}
