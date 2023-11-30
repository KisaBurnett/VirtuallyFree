using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    GameObject scoreCollector;
    GameObject obstacleSFX;

    private void Start()
    {
        scoreCollector = GameObject.FindWithTag("Score");
        obstacleSFX = GameObject.FindWithTag("BadSFX");
    }

    // Upon contact with player, subtract from score and destroy self
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreCollector.GetComponent<ScoreCollector>().score -= 1;
            scoreCollector.GetComponent<ScoreCollector>().ScoreAdd();
            obstacleSFX.GetComponent<AudioSource>().Play();
        }
        Destroy(this.gameObject);
    }
}
