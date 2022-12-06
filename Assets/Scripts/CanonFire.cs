using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    public int damage;
    public float cooldownFire = 0.75f;

    [SerializeField] private Transform _targetAim;
    [SerializeField] private GameObject _cannonball;
    [SerializeField] private Transform _tranformStartPositionShoot;

    private bool flagShoot = true;
 
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
            if (flagShoot)
            {
                var projectile = Instantiate(_cannonball, _tranformStartPositionShoot.position, Quaternion.identity);
                StartCoroutine(Fade());
            }
        }
    }

    IEnumerator Fade()
    {
        flagShoot = false;
        yield return new WaitForSeconds(cooldownFire);
        flagShoot = true;
    }
}
