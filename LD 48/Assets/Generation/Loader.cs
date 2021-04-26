using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    Camera _cam;

    void Update()
    {
        _cam = Camera.main;
        Vector3 check = _cam.WorldToViewportPoint(this.transform.position);



        if (check.x > -.02 && check.x < 1.02)
        {
            Enable(this.gameObject);
            if (check.y > -.02 && check.y < 1.02)
            {
                Enable(this.gameObject);
            }
            else
            {
                Disable(this.gameObject);
            }
        }
        else
        {
            Disable(this.gameObject);
        }

        void Enable(GameObject obj)
        {
            
            obj.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            obj.gameObject.GetComponent<BoxCollider2D>().enabled = true;


            if (obj.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        void Disable(GameObject obj)
        {
            
            obj.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (obj.gameObject.GetComponent<SpriteRenderer>() != null)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}


