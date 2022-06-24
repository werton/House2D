using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Vector3 _moveDirection;

    private void Update()
    {
        Handleinput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Handleinput()
    {
        float shiftX = 0.0f;
        float shiftY = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            shiftX = -1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            shiftX = +1.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            shiftY = +1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            shiftY = -1.0f;
        }

        _moveDirection = new Vector3(shiftX, shiftY).normalized;
    }

    private void Move()
    {
        _rigidbody2D.velocity = _moveDirection * _speed;
    }
}