using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public string Scene;

    public int health;
    public Transform spawn;

    private Rigidbody2D m_rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        Button btn = Jump.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Die();
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

        if (other.gameObject.CompareTag("Damage"))
        {
            
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            Damage();
           
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }

    public void Respawn()
    {
        transform.position = spawn.position;
    }

    public void Damage()
    {      
           Respawn();
            Debug.Log("ouch");           
            health--;      
    }

    public void Die()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(Scene);
        }
    }
    void TaskOnClick()
    {
        if(onGround)
        m_rigidBody2D.AddForce(Vector2.up * verticalForce);

    }
}
