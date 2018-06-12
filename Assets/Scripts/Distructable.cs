using UnityEngine;
using System.Collections;

public class Distructable : MonoBehaviour
{
    public Transform explostionPrefab;
    bool buddySystem = true;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Boom")
        {
            //Instantiate(explostionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
