using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Controls")]
    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float joystickVerticalSensitivity;
    public float horizontalForce;
    public float verticalForce;
    public Button Jump;
    public bool onGround;

    private Rigidbody2D m_rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        Button btn = Jump.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (joystick.Horizontal > joystickHorizontalSensitivity)
        {
            // move right
            m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            transform.localScale = new Vector3(6.0f, 6.0f, 1.0f);

        }
        if (joystick.Horizontal < -joystickHorizontalSensitivity)
        {
            // move left
            m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            transform.localScale = new Vector3(-6.0f, 6.0f, 1.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }


    void TaskOnClick()
    {
        if(onGround)
        m_rigidBody2D.AddForce(Vector2.up * verticalForce);

    }
}
