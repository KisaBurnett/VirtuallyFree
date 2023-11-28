using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSFX : MonoBehaviour
{
    // Upon contact with point, play SFX
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
