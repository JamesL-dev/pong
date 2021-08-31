using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    [SerializeField]
    float speed;
    float height;
    string input;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 5f;
        
    }

    public void Init(bool isRightPaddle) 
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;
        if (isRightPaddle)
        {
            // Place paddle on the right side of screen
            pos = new Vector2(gameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // offset to the left
            input = "paddleRight";
        } 
        else 
        {
            // Place paddle on left side of screen
            pos = new Vector2(gameManager.bottomleft.x, 0);
            pos += Vector2.right * transform.localScale.x; // offset to the right
            input = "paddleLeft";
        }
        // update this paddles position
        transform.position = pos;
        transform.name = input;
    }


    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Check for out of bounds movement and set movement to 0
        if (transform.position.y < gameManager.bottomleft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > gameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate (move * Vector2.up);
    }
}
