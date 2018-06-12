using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    float rotSpeed = 10; //The speed at which we shall rotate.
    float rotLimit = 0;

	void Update () 
    {
        if (RedTank.gameState)
        {
            if (Input.GetKey(KeyCode.DownArrow) && rotLimit >= 0) ///////// Down
            {
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
                rotLimit -= Time.deltaTime;
            }
            else
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
            }

            if (Input.GetKey(KeyCode.UpArrow) && rotLimit <= 2.5f) ///////// UP
            {
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
                rotLimit += Time.deltaTime;
            }
            else
            {
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
            }
        }
	}
}
