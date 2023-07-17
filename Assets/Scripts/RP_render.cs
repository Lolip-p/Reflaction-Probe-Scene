using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RP_render : MonoBehaviour
{
    [SerializeField] private float gorizont = 0;

    private ReflectionProbe RP;

    private void Start()
    {
        RP = GetComponentInChildren<ReflectionProbe>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            RP.transform.position = hit.point + new Vector3(0, 0.05f ,0);

            if (RP.transform.position.y + transform.position.y + 0.1f <= gorizont)
            {
                if (transform.position.y <= gorizont)
                {
                    RP.transform.position = transform.position;
                }
                else
                {
                    RP.transform.position = new Vector3(RP.transform.position.x, hit.point.y - hit.point.y + 0.1f, RP.transform.position.z);
                }
            }
        }
    }
}
