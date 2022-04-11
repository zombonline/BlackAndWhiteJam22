using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class BackgroundResize : MonoBehaviour
{
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
