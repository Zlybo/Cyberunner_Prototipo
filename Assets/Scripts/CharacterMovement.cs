using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 5f;
    public float forward_speed = 1f;
    public float jump_force = 1;
    public float gravity = -1;

    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = forward_speed;

        if (characterController.isGrounded)
        {
            // Asegura que el personaje no esté "flotando" cuando está en el suelo
            move.y = -1f;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                move.y = jump_force;
            }
        }
        else
        {
            move.y += gravity * Time.deltaTime;
        }
        characterController.Move(move * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}