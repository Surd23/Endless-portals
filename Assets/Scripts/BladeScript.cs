using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeScript : MonoBehaviour
{
    protected int damage = 10;

    protected float timer = 1f;
    // Start is called before the first frame update

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        AimAnalizeDamage(other, "Enemy");
    }

    public virtual void AimAnalizeDamage (Collider other, string aim)
    {
        if (other.gameObject.CompareTag(aim) && timer < 0)
        {
            other.gameObject.GetComponent<LiveStats>().HPDamage(damage);
            timer = 1f;
        }
    }
}
