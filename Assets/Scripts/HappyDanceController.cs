using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyDanceController : MonoBehaviour
{
    [SerializeField] GameObject spot1;
    [SerializeField] GameObject spot2;
    [SerializeField] GameObject spot3;
    [SerializeField] GameObject spot4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HappyDanceRoutine());
    }

    IEnumerator HappyDanceRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);

            spot1.SetActive(false);
            spot2.SetActive(true);

            yield return new WaitForSeconds(4);

            spot2.SetActive(false);
            spot3.SetActive(true);

            yield return new WaitForSeconds(4);

            spot3.SetActive(false);
            spot4.SetActive(true);

            yield return new WaitForSeconds(4);

            spot4.SetActive(false);
            spot1.SetActive(true);
        }
    }
}
