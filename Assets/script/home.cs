using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class home : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void playbtn()
    {
        SceneManager.LoadScene("levels");
    }
}
