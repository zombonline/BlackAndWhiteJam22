using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    [SerializeField]
    private int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetID()
    {
        return id;
    }

    public void OpenDoor()
    {
        GetComponent<EraseTile>().Erase();
    }
}
