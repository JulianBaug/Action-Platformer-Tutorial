using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    //Headers
    [Header("Move")]
    public float _moveSpeed = 5f;

    private float _horizontalMovement;

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

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _playerInput = GetComponent<PlayerInput>();

        _animator = GetComponent<Animator>();

        _jumpAction = _playerInput.actions["Jump"];

        _moveAction = _playerInput.actions["Move"];

        _rb.gravityScale = _gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        UpdateSprite();

    }

    void UpdateSprite()
    {
        UpdateFlip();

        if (_rb.velocity.y > 0.005)
        {
            _animator.Play("bunny idle");
        }
        else if (_rb.velocity.y < -0.005)
        {
            _animator.Play("bunny fall");
        }
        else if (Math.Abs(_horizontalMovement) > 0.005)
        {
            _animator.Play("bunny walk");
        }
        else
        {
            _animator.Play("bunny idle");
        }
    }

    private void UpdateFlip()
    {
        if(_horizontalMovement > 0.005 && transform.localScale.x < 0 ||
            _horizontalMovement < -0.005 && transform.localScale.x > 0)
        {
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {

        _rb.velocity = new Vector2(_horizontalMovement * _moveSpeed, _rb.velocity.y);
    }

    private void HandleInput()
    {
        _horizontalMovement = _moveAction.ReadValue<Vector2>().x;

        if (_jumpAction.WasPressedThisFrame() && IsOnGround())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
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

    private void ResetScene()
    {
        // Reload the same scene we are already in

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TakeDamage(float amount)
    {
        ResetScene();
    }
}
