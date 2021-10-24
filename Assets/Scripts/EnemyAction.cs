using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    int attackAnimation = 500;
    float smashTime = 0.25f;
    Vector3 defaltAngle;

    bool isAttack;
    bool deadCheck;

    byte attackTime = 3;
    float attackTimer;

    public GameObject heroEnemy;
    Rigidbody enemyRb;

    int enemySpeed = 300;
    byte velocityStop = 3;

    //int jumpForce = 300;
    //bool isGrounded;

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(smashTime);
        weapon.transform.localEulerAngles = defaltAngle;
        isAttack = false;
    }

    void AttackAHero()
    {
        if (heroEnemy != null && heroEnemy.GetComponent<LiveStats>().hitPoints > 0)
        {
            attackTimer -= Time.deltaTime;

            if (isAttack)
            {
                weapon.transform.Rotate(attackAnimation * Time.deltaTime, 0, 0, Space.Self);
            }

            if (attackTimer < 0)
            {
                attackTimer = Random.Range(0.5f, 2.3f);
                if (heroEnemy != null)
                {
                    float distToHero = (heroEnemy.transform.position - transform.position).magnitude;

                    if (distToHero < 4 && !isAttack)
                    {
                        isAttack = true;
                        StartCoroutine(AttackTime());
                    }
                }
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackTime;
        enemyRb = GetComponent<Rigidbody>();
        defaltAngle = weapon.transform.localEulerAngles;
    }
    void Update()
    {
        if (GetComponent<LiveStats>().hitPoints > 0)
        {
            EnemyMove();

            AttackAHero();
        }
        else
        {
            if (!deadCheck)
            {
                enemyRb.constraints = RigidbodyConstraints.None;

                GameObject gun = transform.Find("Sword").gameObject;
                gun.transform.SetParent(null);
                gun.AddComponent<Rigidbody>();

                GameObject def = transform.Find("Shield").gameObject;
                def.transform.SetParent(null);
                def.AddComponent<Rigidbody>();

                deadCheck = true;
            }
        }
    }

    void EnemyMove()
    {
        if (heroEnemy != null && heroEnemy.GetComponent<LiveStats>().hitPoints > 0)
        {
            transform.LookAt(heroEnemy.transform);
            // velocity constrains
            if (Mathf.Abs(enemyRb.velocity.x) < velocityStop &&
                Mathf.Abs(enemyRb.velocity.y) < velocityStop &&
                Mathf.Abs(enemyRb.velocity.z) < velocityStop)
            {
                Vector3 toHero = (heroEnemy.transform.position - transform.position).normalized;
                enemyRb.AddForce(toHero * enemySpeed);
            }

            enemyRb.angularVelocity = new Vector3(0, 0, 0);
        }
    }

}
