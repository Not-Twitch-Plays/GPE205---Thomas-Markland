using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerSpawnTransform;
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public List<PlayerController> players;

    private void Awake()
    {
        // Setting up Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //No extra instances
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // Spawn a Player Controller
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        newController.myPawn = newPawn;

        //Letting the game know THIS pawn is our player
    }
}