using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehavior : MonoBehaviour
{
    GameObject scoreCollector;

    private void Start()
    {
        scoreCollector = GameObject.FindWithTag("Score");
    }

    // Upon contact with player, add to score and destroy self
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreCollector.GetComponent<ScoreCollector>().score += 1;
            scoreCollector.GetComponent<ScoreCollector>().ScoreAdd();
        }
        Destroy(this.gameObject);
    }
}
