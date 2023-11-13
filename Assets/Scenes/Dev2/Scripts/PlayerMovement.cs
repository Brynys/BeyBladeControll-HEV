using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float TurnSpeed = 180f;
    [SerializeField] private string InputNameHorizontal;
    [SerializeField] private string InputNameVertical;

    private Rigidbody rb;
    private float inputHorizontal;
    private float inputVertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxis(InputNameHorizontal);
        inputVertical = Input.GetAxis(InputNameVertical);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Pohyb vp�ed a vzad
        float move = inputVertical * Speed * Time.deltaTime;

        // Ot��en�
        float turn = inputHorizontal * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Aplikace pohybu a ot��en�
        rb.MovePosition(rb.position + transform.forward * move);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
