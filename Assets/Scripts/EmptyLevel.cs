using UnityEngine;
using System.Collections;

public class EmptyLevel : MonoBehaviour 
{
    float minTimer = 5;
    float secTimer = 0;

    public Texture2D Win;
    public Texture2D Fail;

    float winTimer = 3;
    float failTimer = 3;

    bool win = false;
    bool fail = false;



	void Start () 
    {
        RedTank.gameState = true;
	}
	
	void Update ()
    {
        GameObject midText = GameObject.Find("MiddleText");
        GameObject timer = GameObject.Find("Timer");
        GameObject count = GameObject.Find("BlockCount");

        GameObject[] blocks;
        blocks = GameObject.FindGameObjectsWithTag("Block");

        count.guiText.text = string.Format("{0}", (blocks.Length - 2));

        int num = blocks.Length;

        if (num < 5)
        {
            win = true;
            midText.guiTexture.texture = Win;
        }

        timer.guiText.text = string.Format("{0}:{1}", minTimer, (int)secTimer);

        if (Input.GetKey(KeyCode.Escape))    
            Application.LoadLevel(0);

        secTimer -= Time.deltaTime;

        if (secTimer <= 0)
        {
            secTimer = 60;
            minTimer--;
        }

        if (minTimer <= 0)
        {
            fail = true;
            midText.guiTexture.texture = Fail;
        }


        if (fail)
            failTimer -= Time.deltaTime;

        if (win)
            winTimer -= Time.deltaTime;

        if (failTimer <= 0)
            Application.LoadLevel(0);

        if (winTimer <= 0)
            Application.LoadLevel(0);
	}
}
