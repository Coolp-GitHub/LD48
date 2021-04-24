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



        if (check.x > -.1 && check.x < 1.1)
        {
            Enable(this.gameObject);
            if (check.y > -.05 && check.y < 1.05)
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
            obj.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            obj.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            obj.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        void Disable(GameObject obj)
        {
            obj.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            obj.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            obj.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}


