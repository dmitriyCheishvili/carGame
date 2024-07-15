using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour
{
   public enum PathTypes
    {
        liner,
        loop
    }

    public PathTypes pathType;
    public int movementDirection = 1;
    public int moventTo = 0;
    public Transform[] PathElements;

    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (var i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }

        if (pathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }

    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[moventTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (pathType == PathTypes.liner)
            {
                if (moventTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moventTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            moventTo = moventTo + movementDirection;

            if (pathType == PathTypes.loop)
            {
                if (moventTo >= PathElements.Length)
                {
                    moventTo = 0;
                }

                if (moventTo < 0)
                {
                    moventTo = PathElements.Length - 1;
                }
            }
        }
    }

}
