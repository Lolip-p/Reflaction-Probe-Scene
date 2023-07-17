using System;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    [SerializeField] private float _lerpSpeed = 2.5f;

    [SerializeField] private float _minDistance = .1f;

    private int _current;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _waypoints[_current].position, _lerpSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, _waypoints[_current].position) < _minDistance)
        {
            _current++;

            if( _current >= _waypoints.Length)
            {
                Array.Reverse(_waypoints);
                _current = 0;
            }
        }
    }
}