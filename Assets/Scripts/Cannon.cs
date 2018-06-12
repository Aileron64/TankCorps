using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    float rotSpeed = 20; //The speed at which we shall rotate.

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame*
	void Update () 
    {
        if (RedTank.gameState)
        {
            if (Input.GetKey(KeyCode.RightArrow)) ///////// RIGHT
            {
                transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, -rotSpeed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.LeftArrow)) ///////// LEFT
            {
                transform.Rotate(new Vector3(0, 0, -rotSpeed * Time.deltaTime));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
            }
        }
	}
}
