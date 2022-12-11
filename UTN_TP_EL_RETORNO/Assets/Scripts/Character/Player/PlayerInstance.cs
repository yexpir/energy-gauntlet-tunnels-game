using System;
using UnityEngine;

namespace UTN_TP.Character
{
    public class PlayerInstance : MonoBehaviour
    {
        public static GameObject Instance;
        void Awake() => Instance = gameObject;
    }
}
