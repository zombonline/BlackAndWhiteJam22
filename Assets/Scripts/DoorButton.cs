using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    private DoorHandle[] pairedDoors;

    // Start is called before the first frame update
    void Start()
    {
        //find all doors with same id
        GameObject[] doorObjects = GameObject.FindGameObjectsWithTag("Door");
        List<DoorHandle> doorList = new List<DoorHandle>();
        for (int i = 0; i < doorObjects.Length; i++)
        {
            DoorHandle currDoor = doorObjects[i].GetComponent<DoorHandle>();
            if (currDoor.GetID() == id)
            {
                doorList.Add(currDoor);
            }
        }

        pairedDoors = doorList.ToArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenPairedDoors();
        }

        GetComponent<EraseTile>().Erase();
    }

    private void OpenPairedDoors()
    {
        for (int i = 0; i < pairedDoors.Length; i++)
        {
            pairedDoors[i].OpenDoor();
        }
    }
}
