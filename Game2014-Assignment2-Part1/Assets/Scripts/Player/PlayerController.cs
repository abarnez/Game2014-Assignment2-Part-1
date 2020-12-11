using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


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
    public string Scene1;

    public bool onPlat;
    public float clamp;
    public int health;
    public Transform spawn;
    public AudioSource hit;
    public AudioSource gameover;
    public Animator pAnimation;
    public float Score;
    public TMP_Text score;
    public Animator livesHUD;

    private Transform platform;

    private Rigidbody2D m_rigidBody2D;
    IEnumerator DelayGameOversound()
    {
        gameover.Play();
        //  audioSource.PlayOneShot(gameover);
        pAnimation.SetInteger("AnimState", 2);
        yield return new WaitForSeconds(gameover.clip.length);
        SceneManager.LoadScene(Scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        pAnimation = GetComponent<Animator>();
        health = 3;
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        Button btn = Jump.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(onGround)
        Move();

        Die();
        score.text = "Score: " + Score;
    }

    void Move()
    {
        if (joystick.Horizontal > joystickHorizontalSensitivity)
        {
            // move right
            m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            pAnimation.SetInteger("AnimState", 1);
            transform.localScale = new Vector3(6.0f, 6.0f, 1.0f);
            transform.parent = null;

        }
       else  if (joystick.Horizontal < -joystickHorizontalSensitivity)
        {
            // move left
            m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            transform.localScale = new Vector3(-6.0f, 6.0f, 1.0f);
            pAnimation.SetInteger("AnimState", 1);
            transform.parent = null;
        } else
        {
            pAnimation.SetInteger("AnimState", 0);
           
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Platform"))
        {
            onGround = true;
        }
        
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.gameObject.transform);
            onPlat = true;         
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }
       
        if (other.gameObject.CompareTag("Platform"))
        {        
            transform.SetParent(other.gameObject.transform);
            onPlat = true;
        }      
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Damage")
        {
            Damage();
            pAnimation.SetInteger("AnimState", 2);
        }

        if (other.tag == "Points")
        {
            Score += 10.0f;        
            PlayerPrefs.SetFloat("highscore", Score);
        }

    
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GameEnd")
        {
            Score += 100.0f;
            SceneManager.LoadScene(Scene1);
            PlayerPrefs.SetFloat("highscore", Score);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            platform = other.gameObject.transform;
            transform.SetParent(null);
            onPlat = false;
        }

    }

    public void Respawn()
    {
        if (health > 1)
        {
            transform.position = spawn.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Stop()
    {
        m_rigidBody2D.velocity = new Vector3(0.0f,0.0f,0.0f);
    }

    public void Damage()
    {
        
        
        hit.Play();
           Respawn();                    
            health--;
        livesHUD.SetInteger("livesState", health);
    }

    public void Die()
    {
        
        if (health == 0)
        {
            
            StartCoroutine(DelayGameOversound());
        }
    }
    void TaskOnClick()
    {
        if(onGround)
        m_rigidBody2D.AddForce(Vector2.up * verticalForce);

    }
}
