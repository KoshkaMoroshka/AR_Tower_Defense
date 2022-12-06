using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour {

    public float CastleHp = 150;


    public void Dmg_2(int DMG_2count)
    {
        CastleHp -= DMG_2count;
    }

    private void Update()
    {
        if (CastleHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemyBug")
            CastleHp -= 0.3f * Time.deltaTime;
    }
}
