using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMove : MonoBehaviour
{
    // public int wood = 0;
    // public TextMeshProUGUI WoodText;

    public Camera playerCamera;
    public float mouseSensitivity = 500f;
    private float xRotation = 0f;
 
    public Animator axeAnimator;
    public float jumpForce = 5f;
    private bool isGrounded = false;
    private Rigidbody rb;
void Start () {
    Cursor.lockState = CursorLockMode.Locked;
    rb = GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.freezeRotation = true;
    }
}   
    void Update ()
    {
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
{
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    isGrounded = false;
}

  if (Input.GetMouseButtonDown(0)) 
    {
        SwingAxe();
    }

    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    transform.Rotate(Vector3.up * mouseX);

    transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* 10);  
    transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* 10);      

  
}

void SwingAxe()
{
        Debug.Log("Axe swung!");
    if (axeAnimator != null)
    {
        axeAnimator.SetTrigger("Swing");
    }
}
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("ground"))
    {
        isGrounded = true;
    }
}
}

