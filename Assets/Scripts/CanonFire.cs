using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    public int damage;

    [SerializeField] private Transform _targetAim;
    [SerializeField] private GameObject _cannonball;
    [SerializeField] private Transform _tranformStartPositionShoot;

    private void Start()
    {
        _targetAim = GameObject.FindGameObjectWithTag("Aim").transform;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(_targetAim);

        if (Input.touchCount > 0)
        {
            var projectile = Instantiate(_cannonball, _tranformStartPositionShoot.position, Quaternion.identity);
        }
    }
}
