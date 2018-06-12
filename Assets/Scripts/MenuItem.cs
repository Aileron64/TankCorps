using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour 
{
    public string Button = "";
    public static bool music = true;
    public static int currentLevel = 1;

    

    void Start()
    {
        renderer.material.color = Color.white;
    }

    void OnMouseEnter()
    {
        renderer.material.color = new Color(1, 0.38f, 0.2f);
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    void OnMouseUp()
    {
        GameObject cam = GameObject.Find("MainCamera");

        if (Button == "Start")
            Application.LoadLevel(currentLevel);

        else if (Button == "Sound")
            music = !music;

        else if (Button == "Level")
            cam.animation.Play("levelSelect");

        else if (Button == "Quit")
            Application.Quit();

        else if (Button == "L1")
            Application.LoadLevel(1);

        else if (Button == "L2")
            Application.LoadLevel(2);

        else if (Button == "L3")
            Application.LoadLevel(3);

        else if (Button == "Bonus")
            Application.LoadLevel(4);

        else if (Button == "Back")
            cam.animation.Play("back");
            

    }
}
