using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterTouch : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                string tag = hit.transform.tag;
                Debug.Log(tag);
                switch (tag)
                {
                    case "Hero":
                        Debug.Log("Dead");
                        hit.transform.GetComponent<Hero>().GetDamage(1000);
                        break;
                }
            }
        }
    }
}
