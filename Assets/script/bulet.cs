using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bulet : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject prefabbulet,pre,hold;
    GameObject[] b = new GameObject[100]; 
    public Transform gunn;
    public Sprite img;
    float speed = 5f;
    public int count = 5,remain;
    zombin zombin;
    int[] buletcnt = { 5,5,5,5,5,5,5,5,5,5};
    int i = 0,level;
    int fire,score;

    void Start()
    {
        level = PlayerPrefs.GetInt("level",1);
        zombin = FindObjectOfType<zombin>();
        score = PlayerPrefs.GetInt("score",0);
        fire=buletcnt[level-1];
        for (i = 0; i < buletcnt[level-1];i++)
        {
            b[i] = Instantiate(pre, hold.transform);
            b[i].GetComponent<Image>().sprite = img;

        }
    }

    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            firebulet();
            if(fire>0)
            {
                fire--;
                Destroy(b[fire]);
            }
        }
    }

    void firebulet()
    {
        
        if (count!=0)
        {
            GameObject buulet = Instantiate(prefabbulet, gunn.position, gunn.rotation);
            rb = buulet.GetComponent<Rigidbody2D>();
            rb.velocity = gunn.right * speed;
            Destroy(buulet, 5f);
            count--;
            print("counts = "+count);
        }
        else if(zombin.co==false && count==0)
        {
            StartCoroutine(amolos());
        }
        remain = count;
        print("remain = " + remain);
        if (remain >= 3)
        {
            PlayerPrefs.SetInt("level_star_" + level, 3);
            print("levels = "+level);
        }
        else if (remain == 2)
        {
            PlayerPrefs.SetInt("level_star_" + level, 2);
        }
        else if (remain == 1)
        {
            PlayerPrefs.SetInt("level_star_" + level, 1);
        }
        else if(remain == 0)
        {
            PlayerPrefs.SetInt("level_star_" + level, 0);
        }
    }
    IEnumerator amolos()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("loss");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            Vector2 reflects=Vector2.Reflect(rb.velocity.normalized,collision.contacts[3].normal);
            rb.velocity = reflects * speed;
        }
    }
}
