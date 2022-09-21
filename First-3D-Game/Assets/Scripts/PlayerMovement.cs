using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;
    public float jumpHeight;

    private float _gravity = -20f;

    private CharacterController _characterController;
    private Vector3 _movementVector;
    private Vector3 _rotationVector;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
   
    void Update()
    {
        CharacterMove();
    }

    private void CharacterMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (_characterController.isGrounded)
        {
            _movementVector = transform.forward * playerSpeed * vertical;
            _rotationVector = transform.up * rotationSpeed * 100 * horizontal;

            if (Input.GetButtonDown("Jump"))
            {
                _movementVector.y = jumpHeight;
            }
        }

        _movementVector.y += _gravity * Time.deltaTime;
        _characterController.Move(_movementVector * Time.deltaTime);

        transform.Rotate(_rotationVector * Time.deltaTime);
    }
}
