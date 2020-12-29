using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startlog : MonoBehaviour
{
    public float xposition;
    public float yposition;
    public float zposition;
    // Start is called before the first frame update
    void Update()
    {
        Vector3 velo = Vector3.zero;
        Vector3 check = new Vector3(xposition, yposition, zposition);
        transform.position = Vector3.SmoothDamp(transform.position, check, ref velo, 0.1f);
    }
}
