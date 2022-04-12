using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonId : MonoBehaviour
{
    private LevelID levelId;
    [SerializeField]
    private Text text;

    private AudioSource click, hover;

    // Start is called before the first frame update
    void Start()
    {
        if (levelId.stage == 0 && levelId.level == 0)
        {
            SetID(new LevelID(1, 1));
        }

        click = GameObject.FindGameObjectWithTag("MainClick").GetComponent<AudioSource>();
        hover = GameObject.FindGameObjectWithTag("ButtonHover").GetComponent<AudioSource>();
    }

    public void LevelSelected()
    {
        int index = ((levelId.stage - 1) * 10) + levelId.level;
        SceneManager.LoadScene(index);
    }


    public void SetID(LevelID newID)
    {
        
        levelId = newID;

        if (newID.stage < 4)
        {
            text.text = levelId.stage + "-" + (levelId.level);
        }
        else
        {
            text.text = "Final";
        }
        
    }

    
    public void ClickSound()
    {
        click.Play();
    }

    public void HoverSound()
    {
        hover.Play();
    }

    public struct LevelID 
    {
        public int stage, level;

        public LevelID(int _stage, int _level)
        {
            stage = _stage;
            level = _level;
        }
    }

}
