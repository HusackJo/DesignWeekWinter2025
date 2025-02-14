using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerCamera : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset, cameraVelocity;

    public float minZoom , maxZoom, zoomLimiter;

    private Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }
    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 adjustedPos = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, adjustedPos, ref cameraVelocity, 0.5f);
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
        camera.fieldOfView = newZoom;
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if (bounds.size.x > bounds.size.y)
        {
            return bounds.size.x;
        }
        return bounds.size.y;
    }

    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            if (targets[0] != null)
            {
                return targets[0].position;
            }
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

    public void AddTargetToCamera(Transform newTarget)
    {
        targets.Add(newTarget);
    }
}
