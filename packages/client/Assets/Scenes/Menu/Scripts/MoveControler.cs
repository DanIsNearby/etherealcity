 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControler : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;

    private Vector2 moveInput;
    private Rigidbody playerRigidBody;


    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Run();
    }
    void Run(){
        Vector3 playerVelocity = new Vector3(moveInput.x * moveSpeed, playerRigidBody.velocity.y, moveInput.y * moveSpeed);
        playerRigidBody.velocity = transform.TransformDirection(playerVelocity);
    }
    void OnMove(InputValue value){
        Debug.Log(value);
        moveInput = value.Get<Vector2>();
    }
}
