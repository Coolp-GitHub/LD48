using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public Canvas canvas;
    public Camera cam;

    private bool Pressed = false;
    public void PlayGame()
    {

        if (!Pressed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            canvas.enabled = false;
            cam.enabled = false;
            Pressed = true;
            this.enabled = false;
        }
    }

   
}
