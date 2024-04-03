using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

       

        Vector3 normal = (transform.position - Vector3.zero).normalized;

        Vector3 tangentVector = Vector3.Cross(transform.right, normal).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(tangentVector, normal) * Quaternion.Euler(0f, horizontal * 20f, 0f);


        rb.MoveRotation( Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20f));


        transform.position = Vector3.Normalize(transform.position) * 5.00f;


        rb.velocity = tangentVector * moveSpeed * vertical;
    }



}
