using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private new Light light;
    float minSpeed = 0.01f;
    public float maxSpeed = 0.5f;
    float minIntensity = 0.1f;
    float maxIntensity = 0.5f;
    float dist;
    public GameObject player;


    private void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(run());
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);

            if (dist > 10)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    IEnumerator run()
    {
        while(true)
        {
            light.enabled = true;
            light.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed-2));
        }
    }
}
