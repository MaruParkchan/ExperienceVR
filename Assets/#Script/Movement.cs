using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float moveSpeed = 3.0f;
    private float baseSpeed = 0;

    private CharacterController characterController;
    private bool isMove = false;
    private bool isFreezeMove = false;
    private Vector3 direction;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (isFreezeMove == true)
        {
            baseSpeed = 0;
            return;
        }

        UpdateMove();
    }

    private void UpdateMove()
    {

        if (characterController.isGrounded)
        {
            direction = mainCamera.forward;
            direction = direction.normalized;
            characterController.Move(direction * baseSpeed * Time.deltaTime);
            //    direction.y -= 9.82f * Time.deltaTime;
            //    characterController.Move(direction * baseSpeed * Time.deltaTime);
        }
     //   else if(characterController.isGrounded == false)
        else
        {
            direction = Vector3.zero;
            direction.y -= 9.82f * Time.deltaTime;
            characterController.Move(direction);
        }
  
  //      characterController.Move(direction * baseSpeed * Time.deltaTime);
    }

    public void Move(bool isMove)
    {
        this.isMove = isMove;

        if (isMove)
            baseSpeed = moveSpeed;
        else
            baseSpeed = 0;
    }

    public void IsFreezeMove(bool isMove)
    {
        isFreezeMove = isMove;
    }

    public bool GetMoveFreeze()
    {
        return isFreezeMove;
    }
}
