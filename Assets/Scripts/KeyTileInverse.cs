using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTileInverse : MonoBehaviour
{
    private float currAlpha = 0;
    private float fadeMultiplier = 0.5f;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, currAlpha);
    }

    private void Update()
    {
        if (sprite.color.a > 0)
        {
            sprite.color = new Color(1, 1, 1, currAlpha);
            currAlpha -= Time.deltaTime * fadeMultiplier;
        }
    }

    public void Spotted()
    {
        currAlpha = 1;
        sprite.color = new Color(1,1,1,currAlpha);
    }
}
