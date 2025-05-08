using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class win : MonoBehaviour
{
    public Image img;
    int level,curent;
    public Sprite onestar, twostar, threestar,zero;
    void Start()
    {
        level = PlayerPrefs.GetInt("level",1);
        if(PlayerPrefs.HasKey("level_star_" + level+3))
        {
            img.sprite = threestar;
        }
        else if(PlayerPrefs.HasKey("level_star_" +level+2))
        {
            img.sprite = twostar;
        }
        else if(PlayerPrefs.HasKey("level_star_" +level+1))
        {
            img.sprite = onestar;
        }
        else if(PlayerPrefs.HasKey("level_star_" + level+0))
        {
            img.sprite = zero;
        }
    }

    void Update()
    {
        
    }
    public void nextscene()
    {
        PlayerPrefs.SetInt("level",level);
        SceneManager.LoadScene("level_"+level);
        PlayerPrefs.Save();
    }
  
}
