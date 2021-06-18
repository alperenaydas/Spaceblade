using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBackground : MonoBehaviour
{
    private float textureUnitSizeY;
    private float initialStatus;
    private float speed = -0.001f;

    public GameObject trail;

    private bool warpInitiate = false;
    private bool warping = false;
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        initialStatus = transform.position.y;
    }

    void Update()
    {
        if(warpInitiate || warping)
        {
            return;
        }
        warpInitiate = trail.GetComponent<TrailController>().warping;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(warpInitiate && !warping)
        {
            warpInitiate = false;
            warping = true;
            StartCoroutine(SpeedUp());
        }
        transform.position += new Vector3(0f, speed, 0f) * Time.timeScale;
        if(Mathf.Abs(transform.position.y - initialStatus) >= textureUnitSizeY)
        {
            float offset = (transform.position.y - initialStatus) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, initialStatus + offset, transform.position.z);
        }
    }

    IEnumerator SpeedUp()
    {
        for (float t = 0.0f; t < 2f; t += Time.deltaTime)
        {
            speed = Mathf.Lerp(-0.001f, -0.1f, t / 2f);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        for (float t = 0.0f; t < 2f; t += Time.deltaTime)
        {
            speed = Mathf.Lerp(-0.1f, -0.001f, t / 2f);
            yield return null;
        }
        warping = false;
    }
}
