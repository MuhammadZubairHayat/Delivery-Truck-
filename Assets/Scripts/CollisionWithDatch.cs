using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithDatch : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if(other.gameObject.tag == "Player")
        {
            AttachAndDetachTrailer.instance.Dattached.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AttachAndDetachTrailer.instance.Dattached.gameObject.SetActive(false);
        }
    }
}
