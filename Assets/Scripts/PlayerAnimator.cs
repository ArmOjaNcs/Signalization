using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;

    private const string Rotation = nameof(Rotation);
    private const string MoveDirection = nameof(MoveDirection);
    private const string Idle = nameof(Idle);
    private const string NotMoving = nameof(NotMoving);

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_player.MoveDirection == 0 && _player.Rotation == 0)
            _animator.SetTrigger(Idle);
        else if (_player.MoveDirection == 0)
            _animator.SetTrigger(NotMoving);

        _animator.SetFloat(Rotation, _player.Rotation);
        _animator.SetFloat(MoveDirection, _player.MoveDirection);
    }
}
