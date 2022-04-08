using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeripheralFOV : MonoBehaviour
{

    private float baseViewScale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateSize(int upgradeCount)
    {
        float newScale = baseViewScale + (0.05f * upgradeCount);
        transform.localScale = new Vector3(newScale, newScale, 1);
    }
}
