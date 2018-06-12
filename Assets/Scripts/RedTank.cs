using UnityEngine;
using System.Collections;

public class RedTank : MonoBehaviour 
{
    public int nextLv;

    public static bool gameState = false;
    public static bool alive = true;
    public static bool win = false;
    
    float speed = 4;
    public Texture2D Win;
    public Texture2D Fail;
    public Texture2D One;
    public Texture2D Two;
    public Texture2D Three;
    public Texture2D None;

    float startTimer = 4;
    float winTimer = 5;
    float failTimer = 5;
    bool countDown;

    float blockDisance;

    public Transform explostionPrefab;

    void Start()
    {
        countDown = true;
        gameState = false;
        alive = true;
        win = false;
    }

	void Update () 
    {
        GameObject midText = GameObject.Find("MiddleText");

        if (gameState)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (!gameState && countDown)
        startTimer -= Time.deltaTime;

        if (startTimer <= 0)
        {
            countDown = false;
            gameState = true;
            startTimer = 4;
            midText.guiTexture.texture = None;
        }

        if (startTimer >= 3 && countDown)
            midText.guiTexture.texture = Three;
        else if (startTimer >= 2 && countDown)
            midText.guiTexture.texture = Two;
        else if (startTimer >= 1 && countDown)
            midText.guiTexture.texture = One;

            

        if (Input.GetKey(KeyCode.Escape))     
            Application.LoadLevel(0);
        
        if (!alive)       
            failTimer -= Time.deltaTime;
        
        if (win)        
            winTimer -= Time.deltaTime;
        
        if (failTimer <= 0)        
            Application.LoadLevel(0);


        if (winTimer <= 0)
        {
            MenuItem.currentLevel = nextLv;
            Application.LoadLevel(nextLv);
        }
        
	}

    void OnTriggerEnter(Collider hit)
    {
        GameObject midText = GameObject.Find("MiddleText");
        GameObject camera = GameObject.Find("Camera");
        GameObject camera2 = GameObject.Find("Camera2");

        if (alive)
        {
            if (hit.gameObject.tag == "Boom")
            {
                audio.Play();
                gameState = false;
                alive = false;
                Instantiate(explostionPrefab, transform.position, Quaternion.identity);
                midText.guiTexture.texture = Fail;
                camera2.SetActive(true);
                camera.SetActive(false);
            }

            if (hit.gameObject.tag == "Finish")
            {
                win = true;
                midText.guiTexture.texture = Win;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject midText = GameObject.Find("MiddleText");
        GameObject camera = GameObject.Find("Camera");
        GameObject camera2 = GameObject.Find("Camera2");

        if(alive)
        {
            if (other.gameObject.tag == "Block" || other.gameObject.tag == "Tank")
            {
                audio.Play();
                gameState = false;
                alive = false;
                Instantiate(explostionPrefab, transform.position, Quaternion.identity);
                midText.guiTexture.texture = Fail;
                camera2.SetActive(true);
                camera.SetActive(false);
            }
        }
    }
}
