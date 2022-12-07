using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovment : MonoBehaviour
{
    public float Speed = 20f;
    [SerializeField] private GameObject tower;

    private bool _winFlag = false;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Castle");
        _anim = GetComponent<Animator>();
        _anim.SetBool("RUN", true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_winFlag)
        {
            return;
        }
        transform.LookAt(tower.transform);
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, Time.deltaTime * Speed);

        if (tower.active == false)
        {
            _anim.SetBool("Attack", false);
            _anim.SetBool("Victory", true);
            _winFlag = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Castle")
        {
            Speed = 0;
            _anim.SetBool("RUN", false);
            _anim.SetBool("Attack", true);
        }
    }
}
