using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RP_render : MonoBehaviour
{
    [SerializeField] private float gorizont = 0;
    [SerializeField] private float dist = 0.1f;

    private bool bo = false;
    private bool rpo = false;

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
            RP.transform.position = hit.point + new Vector3(0, dist, 0);

            if (RP.transform.position.y + transform.position.y + dist + 0.05f <= gorizont)
            {
                if (transform.position.y <= gorizont)
                {
                    RP.transform.position = transform.position;
                }
                else
                {
                    RP.transform.position = new Vector3(RP.transform.position.x, hit.point.y - hit.point.y + dist, RP.transform.position.z);
                }
            }
        }
    }

    public void xBounds()
    {
        if (bo)
        {
            RenderSettings.reflectionBounces = 2;
            bo = false;
        }
        else
        {
            RenderSettings.reflectionBounces = 1;
            bo = true;
        }
    }
    public void xSize()
    {
        if (rpo)
        {
            RP.resolution = 1024;
            rpo = false;
        }
        else
        {
            RP.resolution = 512;
            rpo = true;
        }
    }
}
