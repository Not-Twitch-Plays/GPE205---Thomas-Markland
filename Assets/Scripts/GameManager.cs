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
    
    AudioSource music;

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

        //Setting up Music
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("Music Volume");
        music.Play();
    }

    public void SpawnPlayer()
    {

        //Setting Random Player Spawn
        playerSpawnTransform = GameObject.FindGameObjectsWithTag("PlayerSpawn")[Random.Range(0, GameObject.FindGameObjectsWithTag("PlayerSpawn").Length - 1)].transform;
        // Spawn a PlayerController
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        Controller newController = newPlayerObj.GetComponent<Controller>();
        //Spawns a Pawn for our player
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //Links our pawn and controller together
        newController.myPawn = newPawn;
    }
    public void RespawnPlayer(PlayerController pc)
    {

        //Setting Random Player Spawn
        playerSpawnTransform = GameObject.FindGameObjectsWithTag("PlayerSpawn")[Random.Range(0, GameObject.FindGameObjectsWithTag("PlayerSpawn").Length - 1)].transform;
        //Spawns a Pawn for our player
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();
        //Links our pawn and our old controller together
        pc.myPawn = newPawn;
    }
}