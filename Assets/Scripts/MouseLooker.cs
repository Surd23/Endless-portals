using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooker : MonoBehaviour
{
    [SerializeField] GameObject hero;
    Vector3 correction = new Vector3(0, 11, -12);

    RaycastHit hit;
    int raycastLenght = 500;

    public void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, raycastLenght))
        {
            Vector3 point = hit.point;
            if(hero.GetComponent<LiveStats>().hitPoints > 0)
                hero.transform.LookAt(new Vector3(point.x, hero.transform.position.y, point.z), Vector3.up);
        }

        Debug.DrawRay(ray.origin, ray.direction * raycastLenght, Color.yellow);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = hero.transform.position + correction;

        LookAtMouse();
    }
}
