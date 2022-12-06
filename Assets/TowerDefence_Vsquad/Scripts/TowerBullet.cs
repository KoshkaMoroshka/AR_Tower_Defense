using UnityEngine;
using System.Collections;

public class TowerBullet : MonoBehaviour
{

    public float Speed;
    public Vector3 target;
    public GameObject impactParticle; // bullet impact

    public Vector3 impactNormal;
    Vector3 lastBulletPosition;
    public Tower twr;
    float i = 0.05f; // delay time of bullet destruction

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Aim").transform.position;
    }

    private void Update()
    {

        // Bullet move

        if (target != null)
        {

            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * Speed);
            lastBulletPosition = target;

        }

        // Move bullet ( enemy was disapeared )

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, lastBulletPosition, Time.deltaTime * Speed);

            if (transform.position == lastBulletPosition)
            {
                Destroy(gameObject, i);

                // Bullet hit ( enemy was disapeared )

                if (impactParticle != null)
                {
                    impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;  // Tower`s hit
                    Destroy(impactParticle, 3);
                    return;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<GoblinMovment>(out var goblin))
        {
            Destroy(goblin.gameObject);
            GoblinManager.RemoveGoblin(goblin.gameObject);
        }
        Destroy(gameObject, i); // destroy bullet
        impactParticle = Instantiate(impactParticle, target, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
        impactParticle.transform.parent.position = target;
        Destroy(impactParticle, 3);
        return;
    }
}



