using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private const string Vertical = nameof(Vertical);
    private const string Horizontal = nameof(Horizontal);
    private const int BackWalkSpeedDecreaser = 2;

    private float _moveDirection;
    private float _rotation;

    public float MoveDirection => _moveDirection;
    public float Rotation => _rotation;

    private void Update()
    {
        _moveDirection = Input.GetAxis(Vertical);
        _rotation = Input.GetAxis(Horizontal);
        Move();
        Rotate();
    }

    private void Move()
    {
        if (_moveDirection > 0)
            transform.Translate(Vector3.forward * _moveDirection * _moveSpeed * Time.deltaTime);
        else if (_moveDirection < 0)
            transform.Translate(Vector3.forward * _moveDirection * _moveSpeed / BackWalkSpeedDecreaser * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * _rotation * _rotationSpeed *Time.deltaTime);
    }
}
