using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool isGrounded = false;
    public float speed = 10f;
    public float jump = 100f;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    
    private Animator animator;

    Vector2 vec = new Vector2(0, 0);
    // Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        // position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // var movement = Input.GetAxis("Horizontal");
        // transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        // if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRigidbody.velocity.y) < 0) {
        //     playerRigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        // }
        vec = playerRigidbody.velocity;
        if (Input.GetKey(KeyCode.LeftArrow)) {
                // movement.x -= speed;
                if (!mySpriteRenderer.flipX) mySpriteRenderer.flipX = true;
                vec.x = -speed;
                if (isGrounded) {
                    animator.Play("Player_run");
                }
        } else if (Input.GetKey(KeyCode.RightArrow)) {
                // movement.x += speed;

                if (mySpriteRenderer.flipX) mySpriteRenderer.flipX = false;
                vec.x = speed;
                if (isGrounded) {
                    animator.Play("Player_run");
                }
        } else vec.x = 0;
        if (isGrounded && Input.GetKey(KeyCode.Space)) {
            vec.y += jump;
            vec.x = playerRigidbody.velocity.x;
            animator.Play("Player_jump");
        }
    }
    
    private void FixedUpdate() {
        playerRigidbody.velocity = vec;
        //Debug.Log(playerRigidbody.velocity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("items"))
        {
            
            Destroy(other.gameObject);
        }
    }
 
}
