using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeEnemy : BladeScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        AimAnalizeDamage(other, "Player");
    }

    public override void AimAnalizeDamage(Collider other, string aim)
    {
        if ((other.gameObject.CompareTag(aim) || other.gameObject.CompareTag("Comrad")) && timer < 0)
        {
            other.gameObject.GetComponent<LiveStats>().HPDamage(damage);
            timer = 1f;
        }
    }
}
