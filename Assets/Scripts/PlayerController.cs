using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] public float MoveForce { get; private set; } = 12f;
    [field: SerializeField] public CharacterState Idle { get; private set; }
    [field: SerializeField] public CharacterState Walk { get; private set; }
    [field: SerializeField] public CharacterState Use { get; private set; }
    [field: SerializeField] public StateAnimationSetDictionary StateAnimations { get; private set; }
    [field: SerializeField] public float WalkSpeedThreshold { get; private set; } = 0.05f;

    public CharacterState CurrentState
    {
        get => _currentState;
        set
        {
            if (_currentState != value)
            {
                _currentState = value;
                ChangeClip();
                _timeToEndState = _currentClip.length;
            }
        }
    }

    private Vector2 _axisInput = Vector2.zero;
    private Rigidbody2D _rb;
    private Animator _animator;
    private CharacterState _currentState;
    private AnimationClip _currentClip;
    private Vector2 _facingDirection = Vector2.down;
    private float _timeToEndState;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CurrentState = Idle;
    }

    private void Update()
    {
        _timeToEndState = Mathf.Max(_timeToEndState - Time.deltaTime, 0f);
        if (CurrentState.CanExitWhilePlaying || _timeToEndState <= 0f)
        {
            if (_axisInput != Vector2.zero && _rb.velocity.magnitude > WalkSpeedThreshold)
            {
                CurrentState = Walk;
            }
            else
            {
                CurrentState = Idle;
            }
            ChangeClip();
        }
    }

    private void ChangeClip()
    {
        AnimationClip expectedClip = StateAnimations.GetFacingClipFromState(CurrentState, _facingDirection);
        if (_currentClip == null || expectedClip != _currentClip)
        {
            _currentClip = expectedClip;
            _animator.Play(expectedClip.name);
        }
    }

    private void FixedUpdate()
    {
        if (CurrentState.CanMove)
        {
            Vector2 moveForce = MoveForce * _axisInput;
            _rb.AddForce(moveForce);
        }
    }


    private void OnMove(InputValue value)
    {
        _axisInput = value.Get<Vector2>();
        if (_axisInput != Vector2.zero)
        {
            _facingDirection = _axisInput;
        }
    }

    private void OnUse(InputValue value)
    {
        CurrentState = Use;
    }
}
