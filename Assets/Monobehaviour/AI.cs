//Title: Unity For Absolute Beginners
//Auther: Sue Black
//Date: June 2012
//Code Version : N/A
//Availability : www.it-ebooks.info

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(CircleCollider2D))]
public class AI : MonoBehaviour
{
    public float pursuitSpeed = 3f;
    public float wanderSpeed = 1.5f;
    private float currentSpeed;

    public float directionChangeInterval = 2f;
    public float pursuitDuration = 3f;
    public float pursuitCooldown = 6f;

    public bool followPlayer = true;

    private Coroutine moveCoroutine;
    private Rigidbody2D rb2d;

    private Transform targetTransform;
    private Vector3 endPosition;
    private float currentAngle = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetTransform = player.transform;
        }

        StartCoroutine(AIRoutine());
    }

    private IEnumerator AIRoutine()
    {
        while (true)
        {
            // Pursuit phase
            if (followPlayer && targetTransform != null)
            {
                currentSpeed = pursuitSpeed;
                if (moveCoroutine != null) StopCoroutine(moveCoroutine);
                moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed, true));

                yield return new WaitForSeconds(pursuitDuration);
            }

            currentSpeed = wanderSpeed;
            float wanderTime = pursuitCooldown;

            while (wanderTime > 0f)
            {
                ChooseNewEndpoint();
                if (moveCoroutine != null) StopCoroutine(moveCoroutine);
                moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed, false));

                yield return new WaitForSeconds(directionChangeInterval);
                wanderTime -= directionChangeInterval;
            }
        }
    }

    private void ChooseNewEndpoint()
    {
        currentAngle = Random.Range(0f, 360f);
        Vector3 direction = Vector3FromAngle(currentAngle);
        endPosition = transform.position + direction;
    }

    private Vector3 Vector3FromAngle(float angleDegrees)
    {
        float rad = angleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);
    }

    private IEnumerator Move(Rigidbody2D rb, float speed, bool chasing)
    {
        while (true)
        {
            if (chasing && targetTransform != null)
            {
                endPosition = targetTransform.position;
            }

            Vector3 newPosition = Vector3.MoveTowards(rb.position, endPosition, speed * Time.deltaTime);
            rb.MovePosition(newPosition);

            float remainingDistance = (transform.position - endPosition).sqrMagnitude;
            if (!chasing && remainingDistance <= 0.01f)
                break;

            yield return new WaitForFixedUpdate();
        }
    }
}
