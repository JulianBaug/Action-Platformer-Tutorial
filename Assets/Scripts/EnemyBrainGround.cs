using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainGround : MonoBehaviour
{
    [Header("Movement")]
    public float _speed = 5;

    [Header("Collision Checking")]
    public LayerMask _collideLayers;
    public BoxCollider2D _groundCollider;
    public BoxCollider2D _cliffCollider;
    public BoxCollider2D _wallCollider;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnGround() && (isAgainstCliff() || isAgainstWall()))
        {
            //flip the horizontal scale
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        // Mathf.Sign() return 1 for any positive number 
        //  and -1 for any negative number
        _rb.velocity = new Vector2(
            _speed * Mathf.Sign(transform.localScale.x),
            _rb.velocity.y);
    }

    private bool isOnGround()
    {
        return Physics2D.OverlapBox(_groundCollider.bounds.center,
            _groundCollider.bounds.size, 0, _collideLayers);
    }

    private bool isAgainstWall()
    {
        return Physics2D.OverlapBox(_wallCollider.bounds.center,
            _wallCollider.bounds.size, 0, _collideLayers);
    }

    private bool isAgainstCliff()
    {
        // Note the ! at the start. That reverses the logic. This is
        //  because we are against a cliff when we are NOT colliding

        return !Physics2D.OverlapBox(_cliffCollider.bounds.center,
            _cliffCollider.bounds.size, 0, _collideLayers);
    }

    //don't really need this if you select all the children with the main object
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(_groundCollider.bounds.center, _groundCollider.bounds.size);
        Gizmos.DrawWireCube(_cliffCollider.bounds.center, _cliffCollider.bounds.size);
        Gizmos.DrawWireCube(_wallCollider.bounds.center, _wallCollider.bounds.size);
    }

    // no changes to OnCollisionEnter2D

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>()?.TakeDamage(1);
        }
        ;
    }
}