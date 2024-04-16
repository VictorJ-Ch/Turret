using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBikeControl : MonoBehaviour
{
    public float forceMagnitude;
    [Range(0.0f, 10.0f)] public float drag;
    public Transform[] bikedParts;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerInput("Horizontal-P1"); // Jugador 1
        PlayerInput("Jump"); // Jugador 2
        PlayerInput("Horizontal-P2"); // Jugador 3
    }

    void PlayerInput(string buttonName)
    {
        rb.drag = drag;
        if(Input.GetButtonDown(buttonName))
        {
            float dt = Time.deltaTime;
            Vector3 appliedForce = forceMagnitude * transform.forward * dt;
            rb.AddForce(appliedForce, ForceMode.Force);
        }

        float speed = rb.velocity.magnitude;
        float angularSpeed = speed / 0.29f;
        float angle = Mathf.Rad2Deg * Time.deltaTime * angularSpeed;
        for(int i = 0; i < bikedParts.Length; i++)
        {
            bikedParts[i].Rotate(0,0,angle, Space.Self);
        }
    }
}
