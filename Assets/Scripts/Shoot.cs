using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
    public Rigidbody bullet;
    public static int Ammo;
    public static int maxAmmo = 10;
    public float timer;
    public float power = 50;
    

	// Use this for initialization
	void Start () 
    {
        Ammo = 0;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer <= 0 && Ammo > 0 && RedTank.gameState) 
        {
            audio.Play();
            Rigidbody clone;
            clone = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * power);
            Ammo--;
            Debug.Log(Ammo + " Ammo Left");
            timer = 1;
        }
	}
}
