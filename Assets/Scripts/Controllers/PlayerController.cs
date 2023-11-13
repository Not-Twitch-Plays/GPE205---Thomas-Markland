using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

[System.Serializable]
public class PlayerController : Controller
{
    public int lives;
    public int score;
    public int repawnTime;

    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode strafeLeftKey;
    public KeyCode strafeRightKey;
    public KeyCode rotateLeft;
    public KeyCode rotateRight;
    public KeyCode shootKey;
    public KeyCode pauseKey;

    public GameObject myCamera;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject pauseMenu;
    public GameObject gameplayUI;

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
        pauseMenu.SetActive(false);
        gameplayUI.SetActive(true);
        myPawn.turnSpeed = PlayerPrefs.GetFloat("Turn Sensitivity");

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

            //Move our camera based on our POV setting
            switch (PlayerPrefs.GetInt("POV"))
            {
                case 0:
                    //Third Person
                    cameraOffset = new Vector3(0,2.5f,-5);
                    break;
                case 1:
                    //First Person
                    cameraOffset = new Vector3(0, 1.15f, 0);
                    break;
            }
            GameObject cp = myPawn.transform.Find("CameraPivot").gameObject;
            cp.transform.localPosition = cameraOffset;
            myCamera.transform.rotation = cp.transform.rotation;
            myCamera.transform.position = cp.transform.position;

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
                    loseScreen.SetActive(false);
                    winScreen.SetActive(false);
                    pauseMenu.SetActive(false);
                    gameplayUI.SetActive(true);
                    myPawn.turnSpeed = PlayerPrefs.GetFloat("Turn Sensitivity");
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
        if (Input.GetKey(strafeLeftKey))
        {
            myPawn.StrafeLeft();
        }

        if (Input.GetKey(strafeRightKey))
        {
            myPawn.StrafeRight();
        }

        if (Input.GetKey(rotateLeft))
        {
            myPawn.RotateLeft();
        }

        if (Input.GetKey(rotateRight))
        {
            myPawn.RotateRight();
        }
        if (Input.GetKey(shootKey))
        {
            myPawn.Shoot();
        }
        if (Input.GetKey(pauseKey))
        {
            Pause();
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void NewLevel()
    {
        SceneManager.LoadScene("Main");
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        gameplayUI.SetActive(false);
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        pauseMenu.SetActive(false);
        gameplayUI.SetActive(true);
        Time.timeScale = 1;
    }
}