using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour 
{
    float moveAccel = 5; //The acceleration speed that we use
    float moveDecel = -5; //The decelleration speed that we use
    float tankVel = 0; //This is the variable of our velocity. Very important is this.
    float maxSpeed = 15; //This is the max speed we are allowed going.
    float rotSpeed = 20; //The speed at which we shall rotate.
    float jitControl = 0.02f; //The ammount at which velocity is set back to 0.



	void Start () 
    {
        if (MenuItem.music)
            audio.Play();
	}

    void Update()
    {
        //GameObject eta = GameObject.Find("ETA");
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        //    blockDisance = hit.distance;

        //eta.guiText.text = string.Format("{0}", (blockDisance));



        if (RedTank.gameState)
        {
            transform.Translate(new Vector3(0, 0, tankVel * Time.deltaTime)); //// TANK IS MOVING NOW

            if (tankVel <= jitControl && tankVel >= jitControl) ///Prevents Shaking 
            {
                tankVel = 0;
            }


            //////////////////////////////////////////////////--------------   INPUT TIME -------------------------------
            //////////////////////////////////------- MOVEMENT ----------------

            if (Input.GetKey(KeyCode.W)) // FORWARD
            {
                if (tankVel <= maxSpeed)
                {
                    tankVel += moveAccel * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.S)) // BACRWARDS
            {
                if (tankVel >= -maxSpeed)
                {
                    tankVel -= moveAccel * Time.deltaTime;
                }
            }
            else /////// Slows down when notings pressed
            {
                if (tankVel > 0)
                {
                    tankVel += moveDecel * Time.deltaTime;
                }
                else if (tankVel < 0)
                {
                    tankVel -= moveDecel * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.D)) ///////// RIGHT
            {
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.A)) ///////// LEFT
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
            }
        }

        if(!RedTank.alive)
        {
            audio.Stop();
        }
    }



    ////////////////////////////////--------- Getting Ammo --------------
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Crate" && Shoot.Ammo != Shoot.maxAmmo)
        {
            Destroy(hit.gameObject);
            Shoot.Ammo = 10;
        }
    }
}

