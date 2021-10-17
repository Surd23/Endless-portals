using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;

    [SerializeField] int heroSpeed;
    [SerializeField] float velocityStop = 3;
    [SerializeField] int jumpForce = 150;

    float forwardInput;
    float rightInput;
    Rigidbody playerRb;
    
    //bool isGrounded = true;

    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        rightInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(playerRb.velocity.x) < velocityStop &&
            Mathf.Abs(playerRb.velocity.y) < velocityStop &&
            Mathf.Abs(playerRb.velocity.z) < velocityStop)
        {
            playerRb.AddForce(mainCamera.transform.forward * heroSpeed * forwardInput);
            playerRb.AddForce(mainCamera.transform.right * heroSpeed * rightInput);
        }

        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
