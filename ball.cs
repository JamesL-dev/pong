using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction is 1,1?
        radius = transform.localScale.x / 2 ; // half width

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (direction * speed * Time.deltaTime);

        // bounce off top and bottom
        if (transform.position.y < gameManager.bottomleft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > gameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        // Game Over
        if (transform.position.x < gameManager.bottomleft.x + radius && direction.x < 0)
        {
            Debug.Log ("Right player wins!");

            // freeze time
            Time.timeScale = 0;
            enabled = false; // stop updating script
        }
        if (transform.position.x > gameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log ("Left player wins!");
            Time.timeScale = 0;
            enabled = false; // stop updating script
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "paddle")
        {
            bool isRight = other.GetComponent<paddle> ().isRight;
            // hitting right paddle and moving right, flip direction
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            // hitting left paddle and moving left, flip direction
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}