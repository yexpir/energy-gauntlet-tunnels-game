using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimHandler : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform aim;
    [SerializeField] Transform target;

    void Update()
    {
        aim.position = origin.position;
        aim.LookAt(target);
    }
}
