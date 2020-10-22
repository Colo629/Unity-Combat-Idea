using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public MechStatusHolder msh;
    public EnemyDeathCounter edc;
    private int thisScene;
    // Start is called before the first frame update
    void Start()
    {
        thisScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(msh.torsoHp <= 0)
        {
            ReloadLevel();
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("TheProvingGrounds");
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(thisScene);
    }
}
