using System;
using UnityEngine;

namespace UTN_TP.Character
{
    public class Player : MonoBehaviour
    {
        public static GameObject Instance;
        void Awake() => Instance = gameObject;
    }
}
