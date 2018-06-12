using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour 
{
	void Update () 
    {
        transform.Rotate(new Vector3(0, 20 * Time.deltaTime, 0));
	}
}
