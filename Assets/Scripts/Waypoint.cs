using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Image _waypointMarkerImage;
    [SerializeField] private Transform _target;
    [SerializeField] private Text _distanceToWaypoint;
    [SerializeField] private Vector3 _offset;
    private int _errorValue = 10;

    private void Update()
    {
        float minX = _waypointMarkerImage.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = _waypointMarkerImage.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        Vector2 position = Camera.main.WorldToScreenPoint(_target.position + _offset);

        if (Vector3.Dot((_target.position - transform.position), transform.forward) < 0)
        {
            if (position.x < Screen.width / 2)
            {
                position.x = maxX;
            }
            else
            {
                position.x = minX;
            }
        }

        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        _waypointMarkerImage.transform.position = position;
        int distance = (int)Vector3.Distance(_target.position, transform.position) - _errorValue;
        int absoluteDistance = Math.Abs(distance);
        _distanceToWaypoint.text = absoluteDistance.ToString() + " ì";
    }

}
