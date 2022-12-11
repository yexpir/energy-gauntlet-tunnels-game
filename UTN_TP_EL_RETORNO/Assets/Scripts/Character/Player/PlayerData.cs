using UnityEngine;

namespace UTN_TP.Character.Player
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance;

        public float jumpGravity;
        public float fallGravity;
        public float walkSpeed;
        public float runSpeed;
        public float jumpForce;
        public float rotationSpeed;
        public int punchDamage;

        void Awake()
        {
            Instance ??= this;
            Physics.gravity = Vector3.down * Mathf.Abs(fallGravity);
        }
    }
}
