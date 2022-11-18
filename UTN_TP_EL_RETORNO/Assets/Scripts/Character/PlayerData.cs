using UnityEngine;

namespace UTN_TP.Character
{
    public class PlayerData : MonoBehaviour
    {
        public float jumpGravity;
        public float fallGravity;
        public float walkSpeed;
        public float runSpeed;
        public float jumpForce;
        public  float rotationSpeed;

        void Awake() => Physics.gravity = Vector3.down * Mathf.Abs(fallGravity);
    }
}
