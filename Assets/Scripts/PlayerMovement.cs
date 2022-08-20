using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float speedHorizontal = 2.0f;
    [SerializeField] float speedVertical = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CamControls();
        ConstrainMovement();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
    void CamControls()
    {
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch -= speedVertical * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
    void ConstrainMovement()
    {
        float ypos = 0.5f;
        if(transform.position.y< -ypos)
        {
            transform.position = new Vector3(transform.position.x, -ypos, transform.position.z);
        }
        if (transform.position.y > ypos)
        {
            transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        }
    }
}
