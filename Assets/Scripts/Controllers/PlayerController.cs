using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : Controller
{
    public int lives;
    public int score;
    public int repawnTime;

    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public KeyCode shoot;

    public GameObject myCamera;
    public GameObject loseScreen;
    public GameObject winScreen;

    public Slider healthBar;

    public TextMeshProUGUI livesCounter;
    public TextMeshProUGUI scoreCounter;

    public Vector3 cameraOffset;

    float deathTimer;

    bool isDead;

    Health myHealth;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        lives = 5;
        score = 0;
        myHealth = myPawn.GetComponent<Health>();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);

        //Registering w/ GameManager
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players != null)
            {
                GameManager.instance.players.Add(this);
            }
        }
    }

    public override void Update()
    {
        base.Update();
        if (myPawn != null)
        {
            //If we have a pawn, handle input and make sure the deathTimer is at 0
            HandleInput();
            deathTimer = 0;

            //Move our camera to look at our tank
            myCamera.transform.position = Vector3.Lerp(myCamera.transform.position, myPawn.transform.position + cameraOffset, 10 * Time.deltaTime);

            //Update the UI
            healthBar.maxValue = myHealth.maxHealth;
            healthBar.value = myHealth.health;
            livesCounter.text = lives.ToString();
            scoreCounter.text = score.ToString();

            //If there are no emenies left, we win :)
            if (GameObject.FindAnyObjectByType<AIController>() == null)
            {
                winScreen.SetActive(true);
            }
        }
        else
        {
            //if weve been dead for long enough, and we have an extra life...
            if (isDead)
            {
                deathTimer += Time.deltaTime;
                if (deathTimer >= repawnTime && lives != 0)
                {
                    //Respawn a new tank
                    GameManager.instance.RespawnPlayer(this);
                    myHealth = myPawn.GetComponent<Health>();
                    isDead = false;
                }
                //If we run out of lives, we lose :(
                if (lives == 0)
                {
                    loseScreen.SetActive(true);
                }
            }
            else
            {
                //when we first die, take a life away (and mark us as dead so we only take one life)
                lives--;
                isDead = true;
            }
        }
    }

    public override void HandleInput()
    {
        if (Input.GetKey(moveForwardKey))
        {
            myPawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            myPawn.MoveBackward();
        }

        if (Input.GetKey(rotateLeft))
        {
            myPawn.RotateLeft();
        }

        if (Input.GetKey(rotateRight))
        {
            myPawn.RotateRight();
        }
        if (Input.GetKey(shoot))
        {
            myPawn.Shoot();
        }

    }
    public void OnDestroy()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                // Deregister with the GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NewLevel()
    {
        SceneManager.LoadScene("Main");
    }
}