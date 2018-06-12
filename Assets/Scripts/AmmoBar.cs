using UnityEngine;
using System.Collections;

public class AmmoBar : MonoBehaviour 
{
    public Texture2D[] Ammo = new Texture2D[11];

	void Update () 
    {
        guiTexture.texture = Ammo[Shoot.Ammo];
	}
}
