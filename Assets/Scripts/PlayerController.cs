using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class NewBehaviourScript : MonoBehaviour
{
    [Header("Move")]
    public float _moveSpeed = 5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var xPush = _moveAction.ReadValue<Vector2>().x;

        _rb.velocity = new Vector2(xPush * _moveSpeed, _rb.velocity.y);
    }
}
