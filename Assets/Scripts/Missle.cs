using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

    public Transform explostionPrefab;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("BOOM");
        
        Instantiate(explostionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
