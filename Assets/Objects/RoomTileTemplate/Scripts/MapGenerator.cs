using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] level;

    private void Awake()
    {
        GenerateMap();
    }

    private void Start()
    {
        if (GameManager.instance != null)
        {
            Debug.Log("Spawning Player");
            GameManager.instance.SpawnPlayer();
        }
    }

    //Returns a random room
    public GameObject RandomRoomPrefab()
    {
        return levelPrefabs[Random.Range(0, levelPrefabs.Length)];
    }

    public void GenerateMap()
    {
        // Clear out the level - "column" is our X, "row" is our Y
        level = new Room[cols, rows];

        // For each level row...
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // for each column in that row
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                // Figure out the location. 
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                // Create a new level at the appropriate location
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                // Set its parent
                tempRoomObj.transform.parent = this.transform;

                // Give it a meaningful name
                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                // Get the room object
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                // Save it to the level array
                level[currentCol, currentRow] = tempRoom;
                ////////////////////////////////////////////////////////////////////////////
                // Open the doors
                // If we are on the bottom row, open the north door
                if (currentRow == 0)
                {
                    Destroy(tempRoom.doorNorth);
                }
                else if (currentRow == rows - 1)
                {
                    // Otherwise, if we are on the top row, open the south door
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    // Otherwise, we are in the middle, so open both doors
                    Destroy(tempRoom.doorNorth);
                    Destroy(tempRoom.doorSouth);
                }
                /////////////////////////////////////////////////////////////////////////////
                // If we are on the left column, open the east door
                if (currentCol == 0)
                {
                    Destroy(tempRoom.doorEast);
                }
                else if (currentCol == rows - 1)
                {
                    // Otherwise, if we are on the right column, open the west door
                    Destroy(tempRoom.doorWest);
                }
                else
                {
                    // Otherwise, we are in the middle, so open both doors
                    Destroy(tempRoom.doorEast);
                    Destroy(tempRoom.doorWest);
                }
            }
        }
    }
}
