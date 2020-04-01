using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public GameObject snakeBodyPrefab;
    public Transform transform;
    public Text text;

    public float turnTime = .5f;
    public float moveSpeed = 1;
    public float difficulty = .01f;

    private int score;
    private Direction direction;
    private Direction lastMove;
    
    private List<GameObject> snakeBodies;

    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Up;
        InvokeRepeating("Move", 0f, turnTime);
        score = 0;
        snakeBodies = new List<GameObject>();
        lastMove = Direction.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pauser.IsPaused() && !Pauser.IsFirstPaused())
            return;

        // Only handles input
        if (Input.GetKey("w") && lastMove != Direction.Down)
        {
            direction = Direction.Up;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("a") && lastMove != Direction.Right)
        { 
            direction = Direction.Left;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetKey("s") && lastMove != Direction.Up)
        { 
            direction = Direction.Down;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKey("d") && lastMove != Direction.Left)
        { 
            direction = Direction.Right;
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }

    void Move()
    {
        if (Pauser.IsPaused())
            return;

        HandleSnakeBodies();
        CreateSnakeBody();

        if (direction == Direction.Up)
            transform.position += new Vector3(0, moveSpeed, 0);
        else if (direction == Direction.Down)
            transform.position += new Vector3(0, -moveSpeed, 0);
        else if (direction == Direction.Right)
            transform.position += new Vector3(moveSpeed, 0, 0);
        else if (direction == Direction.Left)
            transform.position += new Vector3(-moveSpeed, 0, 0);

        lastMove = direction;

        Debug.Log("Player moved to " + transform.position);
    }

    void CreateSnakeBody()
    {
        if (score == 0)
            return;

        GameObject snakeBody = Instantiate(snakeBodyPrefab, transform.position, transform.rotation) as GameObject;
        snakeBodies.Add(snakeBody);
    }

    void HandleSnakeBodies()
    {
        for (int i = snakeBodies.Count - 1; i >= 0; i--)
        {
            if (snakeBodies[i] != null)
                snakeBodies[i].SendMessage("Move", score);
            else
                snakeBodies.RemoveAt(i);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameEnder")
        {
            Debug.Log("Game over!");
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Apple")
        {
            score++;
            text.text = "Score: " + score.ToString();

            turnTime -= difficulty;

            CancelInvoke();
            InvokeRepeating("Move", turnTime, turnTime);

            Debug.Log("Score: " + score.ToString());
            Debug.Log("Turn Time: " + turnTime.ToString());
        }
    }
}
