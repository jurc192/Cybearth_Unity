using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    float minFlickerSpeed = 0.1f;
    float maxFlickerSpeed = 0.5f;

    Light lux;

    void Start()
    {
        lux = transform.GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        lux.enabled = true;
        lux.color = new Color(0f, Random.Range(55/255f,155/255f), 1f, 1f);

        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));
        lux.enabled = false;
        yield return new WaitForSeconds (Random.Range(minFlickerSpeed, maxFlickerSpeed));

        StartCoroutine(Flicker());
    }
}
