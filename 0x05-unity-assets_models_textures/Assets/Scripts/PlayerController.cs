using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public CharacterController controller;
  private bool groundedPlayer;
  private Vector3 playerVelocity;
  public float playerSpeed = 6.0f;
  public float verticalSpeed = 0;
  public float jumpHeight = 1.5f;
  public float gravityValue = -9.81f;

  Vector3 originalPos;
  void Awake()
  {
    originalPos = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
  }

  void FixedUpdate()
  {
    Move();
    CheckInfiniteFalling();
  }

  void Move()
  {
    float horizontalMove = Input.GetAxis("Horizontal");
    float verticalMove = Input.GetAxis("Vertical");
    groundedPlayer = controller.isGrounded;

    if (groundedPlayer && playerVelocity.y < 0)
    {
      playerVelocity.y = 0f;
    }

    Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
    controller.Move(playerSpeed * Time.deltaTime * move);


    if (Input.GetButtonDown("Jump") && groundedPlayer)
      playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

    playerVelocity.y += gravityValue * Time.deltaTime;
    controller.Move(playerVelocity * Time.deltaTime);
  }

  void CheckInfiniteFalling()
  {
    if (transform.position.y <= -20)
    {
      transform.position = originalPos;
    }
  }
}