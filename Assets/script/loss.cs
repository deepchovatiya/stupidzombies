using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loss : MonoBehaviour
{
    int level = 1;
    void Start()
    {
        level = PlayerPrefs.GetInt("level",1);
    }

    void Update()
    {
        
    }
    public void retrygame()
    {
        SceneManager.LoadScene("level_"+level);
    }
}
