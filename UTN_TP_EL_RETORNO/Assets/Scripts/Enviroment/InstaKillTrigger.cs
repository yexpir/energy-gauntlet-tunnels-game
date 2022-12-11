using System;
using UnityEngine;
using UTN_TP.Character;

namespace UTN_TP.Enviroment
{
    public class InstaKillTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            print(other.gameObject.name);
            var character = other.GetComponent<IKillable>();
            character?.Die();
        }
    }
}
