using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.SearchService;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpHeight;

    private Rigidbody2D _rbody;
    private CapsuleCollider2D _capsuleCollider;
    
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalVector = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalVector, 0, 0) * playerSpeed * Time.deltaTime;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rbody.velocity.y) < 0.5f)
        {
            _rbody.AddForce(new Vector2(0, playerJumpHeight), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
