using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector3 _moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float shiftX = 0f;
        float shiftY = 0f;
        float angle = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            shiftX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            shiftX = +1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            shiftY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            shiftY = -1f;
        }

        _moveDirection = new Vector3(shiftX, shiftY).normalized;
    }

    private void FixedUpdate()
    {
        Move();
        
    }
    void Move()
    {
        _rigidbody2D.velocity = _moveDirection * _speed;    
    }
}
