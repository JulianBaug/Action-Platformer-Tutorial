using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class NewBehaviourScript : MonoBehaviour
{
    //Headers
    [Header("Move")]
    public float _moveSpeed = 5f;

    [Header("Jump")]
    public float _jumpPower = 5f;

    public float _gravityScale = 0.7f;

    [Header("Ground Check")]
    public LayerMask _groundLayer;

    public Collider2D _groundCollider;

    //References

    private Rigidbody2D _rb;

    private PlayerInput _playerInput;

    private InputAction _jumpAction;

    private InputAction _moveAction;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _playerInput = GetComponent<PlayerInput>();

        _jumpAction = _playerInput.actions["Jump"];

        _moveAction = _playerInput.actions["Move"];

        _rb.gravityScale = _gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (_jumpAction.WasPressedThisFrame() && IsOnGround())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }

    void FixedUpdate()
    {
        var xPush = _moveAction.ReadValue<Vector2>().x;

        _rb.velocity = new Vector2(xPush * _moveSpeed, _rb.velocity.y);
    }

    public bool IsOnGround()
    {
        bool overlap = Physics2D.OverlapBox(
            _groundCollider.bounds.center, 
            _groundCollider.bounds.size, 
            0f, 
            _groundLayer);

        return overlap;
    }
}
