using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EraseTile : MonoBehaviour
{
    private Tilemap map;
    [SerializeField]
    private string tileMapName;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find(tileMapName).GetComponent<Tilemap>();
    }

    public void Erase()
    {
        StartCoroutine(DelayedDestroy());
        
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3Int tilePos = map.WorldToCell(transform.position);
        map.SetTile(tilePos, null);
    }
}
