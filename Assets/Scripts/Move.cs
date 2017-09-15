using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Exercice fait avec Gui Volgyesi, le 4.2 marche mais ne tourne pas.
public class Move : MonoBehaviour
{
    float speed = 4f;
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    List<Vector3> points = new List<Vector3>();
    Vector3 goal;
    Vector2 direction;
    Vector2 movement;

    int index = 0;
    float precision = 0.1f;
    float stopTimer = 0.0f;
    const float stopPeriod = 3.0f;
    bool move = true;

    void Start()

    {
        goal = points[0];
    }

    void Update()

    {
        direction = (goal - transform.position).normalized;
        movement = speed * direction;
        if (Vector3.Distance(transform.position, goal) <= precision)
        {
            if (index <= points.Count)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            goal = points[index];
            move = false;
            StartCoroutine(stop());
        }

    }

    private void FixedUpdate()

    {
        if (move)
        {
            body.velocity = movement;
        }
        if (!move)
        {
            body.velocity = Vector3.zero;
        }
    }

    IEnumerator stop()

    {
        yield return new WaitForSeconds(1);
        move = true;
    }
}