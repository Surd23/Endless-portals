using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveStats : MonoBehaviour
{
    public int hitPoints;

    //int headHp = 10;
    //int bodyHp = 50;
    //int armsHp = 20;
    //int legsHp = 20;

    public void HPDamage(int dd)
    {
        hitPoints -= dd;
        Debug.Log(dd + " damage was dealen!");
    }
}
