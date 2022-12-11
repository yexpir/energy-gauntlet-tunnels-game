using System;
using UnityEngine;
namespace UTN_TP.GameManagement
{
    public class DontDestroy : MonoBehaviour
    {
        public bool Undestroyable;
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Undestroyable = true;
        }
    }
}