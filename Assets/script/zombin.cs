using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class zombin : MonoBehaviour
{
    Rigidbody2D br;
    Animator animator;
    public int totalzombie;
    int level=1;
    int max = 0;
    int score = 0;
    public bool co;
    void Start()
    {
        animator = GetComponent<Animator> ();
        level = PlayerPrefs.GetInt("level",1);
        max = PlayerPrefs.GetInt("max",0);
        score = PlayerPrefs.GetInt("score",0);
        totalzombie = GameObject.FindGameObjectsWithTag("zombie").Length;
        print("before zombie = "+totalzombie);
        co = false;
    }

    void Update()
    {
        if (totalzombie == 0)
        {
            PlayerPrefs.SetInt("level", level + 1);
            SceneManager.LoadScene("win");
            co= true;
            if (level > max)
            {
                PlayerPrefs.SetInt("max", level);
                PlayerPrefs.SetInt("score", score + 100);
                print("score= "+score);

            }
        }
        else
        {
            co= false;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulet")
        {
            animator.SetTrigger("died");
            gameObject.tag = "dead";
            totalzombie = GameObject.FindGameObjectsWithTag("zombie").Length;
            print("after zombie = " + totalzombie);
            
        }
    }
}
