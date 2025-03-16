using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow : MonoBehaviour
{

    public float speed = 4.0f;
    public List<Vector3> path;
    private Vector3 target;

    private int index = 0;
    public bool reverse = false;

    private void Start()
    {
        target = path[index];
    }


    void Update()
    {
        if (path.Count == 0)

        {
            target = path[(index)];
        }



        if (Vector3.Distance(transform.position, target) < 0.3f)
        {
            index++;
            if (index >= path.Count)
            {
                index = 0;

                if (reverse) path.Reverse();
            }
            target = path[index];




        }
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < path.Count - 1; i++)
        {

            Gizmos.DrawLine(path[i], path[i + 1]);
        }


    }
}
