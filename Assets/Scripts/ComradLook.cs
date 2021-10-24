using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComradLook : MonoBehaviour
{
    [SerializeField] GameObject comrad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            comrad.GetComponent<ComradAction>().heroEnemy = other.gameObject;
    }
}
