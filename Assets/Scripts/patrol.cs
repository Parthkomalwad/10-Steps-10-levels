using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patrol : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    public float distance;
    private bool checkingPurpose = true;
    public float movingSpeed;
    public GameObject panel;
    private bool canMove = true;
    private Rigidbody2D ri;
    private BoxCollider2D box;
    int health = 3;


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    

        
    
    private void OnTriggerEnter2D(Collider2D collusion)
    {
        
        
            if (collusion.gameObject.name == "LevelEnd")
            {
                LoadNextScene();

            }
            else if (health == 0)
            {
            panel.SetActive(true);
            canMove = false;
            ri.velocity = Vector2.up * 0.5f;
            ri.gravityScale = 1;

            }
            else 
            {
                health--;
            }
        
        
        
    }
    
    private void movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void Start()
    {
        ri = transform.GetComponent<Rigidbody2D>();
        panel.SetActive(false);
        ri.gravityScale = 0;
        box = this.GetComponent<BoxCollider2D>();
        health = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canMove == true )
        {
            if (checkingPurpose == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z);
                speed = 0;
                checkingPurpose = false;
                

            }
            else 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z);
                speed = movingSpeed;
                checkingPurpose = true;
            }
            
        }
        movement();
        
        
        
       
    }
   
}
