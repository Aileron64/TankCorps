using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

    float blockDisance;
	

	void Update () 
    {
        GameObject eta = GameObject.Find("ETA");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
            blockDisance = hit.distance;

        eta.guiText.text = string.Format("{0}", (blockDisance));

	}
}
