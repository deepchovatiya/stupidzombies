using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runs : MonoBehaviour
{
    float spd = 0.03f;
    bool ismove = true;
    void Start()
    {

    }

    void Update()
    {
        if(this.gameObject.tag!="dead")
        {
            if (ismove)
            {
                transform.position = new Vector2(transform.position.x + spd, transform.position.y);
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.position = new Vector2(transform.position.x - spd, transform.position.y);
                transform.localScale = new Vector3(-1, 1, 1);

            }
            if (transform.rotation.z > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), spd);
            }
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rightco")
        {
            ismove = false;
        }
        if (collision.gameObject.tag == "leftco")
        {
            ismove = true;
        }
    }
}
