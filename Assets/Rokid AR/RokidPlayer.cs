using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RokidPlayer : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5.0f;
    public float gravity = -9.8f;
    public float jumpHeight = 1.0f;
    private float speadY; // 垂直速度
    private bool isGrounded;

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        isGrounded = controller.isGrounded; // 检查是否在地面上

        if (isGrounded && speadY < 0)
        {
            speadY = -2f; // 在着地时重置垂直速度
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // 应用重力
        if (!isGrounded)
        {
            speadY += gravity * Time.deltaTime;
        }

        // 移动角色
        controller.Move((moveDirection * speed + Vector3.up * speadY) * Time.deltaTime);
    }
    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            speadY = Mathf.Sqrt(2 * jumpHeight * -gravity); // 计算跳跃速度
        }
    }
}
