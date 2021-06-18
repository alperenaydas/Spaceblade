using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TrailController : MonoBehaviour
{

    private VisualEffect visualEffect;

    public AudioSource audioSource;
    public AudioClip warp1;
    public AudioClip warp2;

    public bool warping = false;

    static Vector3 initialVelocity = new Vector3(0, -0.15f, 0);
    Vector3 velocity = initialVelocity;
    int rate = 5;

    static Vector3 initialScale = new Vector3(1, 1, 1);
    Vector3 scale = initialScale;

    void Start()
    {
        visualEffect = GetComponent<VisualEffect>();
    }
    void Update()
    {
        visualEffect.SetVector3("velocity", velocity);
        visualEffect.SetInt("rate", rate);
        visualEffect.SetVector3("scale", scale);
    }

    public IEnumerator WarpStart()
    {
        audioSource.PlayOneShot(warp1);
        warping = true;

        float duration = 2f;
        for(float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            rate = (int) Mathf.Lerp(5, 1000, t / duration);
            velocity = Vector3.Lerp(initialVelocity, new Vector3(0, -20f, 0), t / duration);
            scale = Vector3.Lerp(initialScale, new Vector3(1, 20f, 1), t / duration);
            yield return null;
        }
        StartCoroutine(WarpWait());

        warping = false;
    }

    IEnumerator WarpWait()
    {
        float duration = 3f;
        for(float t=0.0f;t<duration;t+=Time.deltaTime)
        {
            yield return null;
        }
        StartCoroutine(WarpFinish());
    }

    IEnumerator WarpFinish()
    {
        audioSource.PlayOneShot(warp2);
        float duration = 2f;
        for (float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            rate = (int)Mathf.Lerp(1000, 5, t / duration);
            velocity = Vector3.Lerp(new Vector3(0, -20f, 0), initialVelocity, t / duration);
            scale = Vector3.Lerp(new Vector3(1, 20f, 1), initialScale, t / duration);
            yield return null;
        }
        rate = 5;
        velocity = initialVelocity;
        Debug.Log("Warp finished.");
    }
}
