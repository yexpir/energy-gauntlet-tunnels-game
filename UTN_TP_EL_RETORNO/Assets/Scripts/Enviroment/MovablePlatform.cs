using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UTN_TP.Character;

namespace UTN_TP.Enviroment
{
    public class MovablePlatform : MonoBehaviour
    {
        Transform _oldParent;
        void OnTriggerEnter(Collider other)
        {
            _oldParent = other.transform.parent;
            other.transform.SetParent(transform, true);
        }

        void OnTriggerExit(Collider other)
        {
            other.transform.SetParent(_oldParent);
        }
    }
}
