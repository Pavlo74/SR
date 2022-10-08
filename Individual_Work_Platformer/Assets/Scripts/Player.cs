using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float jumpHeight = 15f;
    BoxCollider boxleCollider;
    CapsuleCollider capsuleCollider;
    Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        boxleCollider = GetComponent<BoxCollider>();
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            
            //   Vector2 jumpVector = new Vector2(0f,jumpHeight);
            //    rbody.velocity += jumpVector;
            rbody.AddForce(Vector2.up * jumpHeight, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Time.timeScale = 0;//???? ??????? ??????????, ?? ??? ???????????
           
        }
    }
}
