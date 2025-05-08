using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guncontrol : MonoBehaviour
{
    LineRenderer lin;
    public GameObject guns,cross;
    void Start()
    {
        lin = guns.GetComponent<LineRenderer>();
        
    }

    void Update()
    {
        Vector2 gun=transform.position;
        Vector2 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);

       // Vector2 crossposX=cross.transform.position;
        //lin.SetPosition(0, guns.transform.position);
        //lin.SetPosition(1, crossposX);

        Vector2 off=new Vector2( mouse.x-gun.x,mouse.y-gun.y );
        float angle=Mathf.Atan2(off.y,off.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if(angle<=90 && angle>=-90)
        {
            transform.rotation=Quaternion.Euler(0, 0, angle);
        }
    }
}
