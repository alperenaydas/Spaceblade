using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyFollowPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5f;
    float distanceTravelled;
    public EndOfPathInstruction end;
    public Vector2 afterPath;

    private bool pathFinished = false;
    private bool settleFinished = true;
    private bool anim = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(!pathFinished)
        {
            Path();
        }
        if(!settleFinished)
        {
            StartCoroutine(Settle());
        }
        if(anim)
        {
            animator.enabled = true;
            anim = false;
        }
    }

    void Path()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.parent.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
        Quaternion rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end);
        transform.parent.rotation = new Quaternion(0f, 0f, rotation.z, rotation.w);

        if (transform.parent.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1))
        {
            pathFinished = true;
            settleFinished = false;
        }
    }

    IEnumerator Settle()
    {
        float duration = 0.5f;
        for (float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            transform.parent.position = Vector3.Lerp(transform.parent.position, new Vector3(afterPath.x, afterPath.y, 10f), t / duration);
            yield return null;
        }
        transform.parent.rotation = Quaternion.Euler(0f, 0f, 0f);
        settleFinished = true;
        anim = true;
    }
}
