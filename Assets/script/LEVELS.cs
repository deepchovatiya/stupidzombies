using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LEVELS : MonoBehaviour
{
    int level,i,max;
    public Button[] allbtn; 
    void Start()
    {
        level = PlayerPrefs.GetInt("level",1);
        max = PlayerPrefs.GetInt("max",0);
        for (i = 0; i <=max; i++)
        {
            allbtn[i].interactable = true;
        }
    }

    void Update()
    {
        
    }
    public void levelindex(int level)
    {
        PlayerPrefs.SetInt("level",level);
        SceneManager.LoadScene("level_" + level);
    }
}
