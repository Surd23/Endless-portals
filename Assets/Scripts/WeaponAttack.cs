using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    [SerializeField] int attackAnimation;
    [SerializeField] float smashTime;

    Vector3 defaltAngle;
    bool isAttack;

    private void Awake()
    {
        defaltAngle = weapon.transform.localEulerAngles;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        { 
            isAttack = true;
            StartCoroutine(AttackTime());
        }

        if(isAttack)
        { 
            weapon.transform.Rotate(attackAnimation * Time.deltaTime, 0, 0, Space.Self);            
        }

    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(smashTime);
        weapon.transform.localEulerAngles = defaltAngle;
        isAttack = false;
    }

}
