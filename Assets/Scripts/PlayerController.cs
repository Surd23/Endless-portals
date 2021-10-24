using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int heroSpeed;
    [SerializeField] float velocityStop = 3;
    [SerializeField] int jumpForce = 150;

    float forwardInput;
    float rightInput;
    Rigidbody playerRb;
    
    bool isGrounded;
    bool deadCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<LiveStats>().hitPoints > 0)
        {
            PlayerMove();

            PlayerJump();
        }
        else
        {
            if (!deadCheck)
            {
                playerRb.constraints = RigidbodyConstraints.None;

                GameObject gun = transform.Find("Sword").gameObject;
                gun.transform.SetParent(null);
                gun.AddComponent<Rigidbody>();

                GameObject def = transform.Find("Shield").gameObject;
                def.transform.SetParent(null);
                def.AddComponent<Rigidbody>();

                deadCheck = true;
            }
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            isGrounded = true;
    }

    void PlayerMove()
    {
        forwardInput = Input.GetAxis("Vertical");
        rightInput = Input.GetAxis("Horizontal");
               
        // velocity constrains
        if (Mathf.Abs(playerRb.velocity.x) < velocityStop &&
            Mathf.Abs(playerRb.velocity.y) < velocityStop &&
            Mathf.Abs(playerRb.velocity.z) < velocityStop)
        {
            playerRb.AddForce(Vector3.forward * heroSpeed * forwardInput);
            playerRb.AddForce(Vector3.right * heroSpeed * rightInput);
        }

        playerRb.angularVelocity = new Vector3(0,0,0);
    }
}
