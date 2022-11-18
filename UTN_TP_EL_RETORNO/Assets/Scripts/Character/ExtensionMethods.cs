using UnityEngine;

namespace UTN_TP.Character
{
    public static class ExtensionMethods
    {
        public static void SetVelX(this Rigidbody r, float x)
        {
            var v = r.velocity;
            r.velocity = new Vector3(x, v.y, v.z);
        }
        public static void SetVelY(this Rigidbody r, float y)
        {
            var v = r.velocity;
            r.velocity = new Vector3(v.x, y, v.z);
        }
        public static void SetVelZ(this Rigidbody r, float z)
        {
            var v = r.velocity;
            r.velocity = new Vector3(v.x, v.y, z);
        }
        public static void SetVelXY(this Rigidbody r, Vector3 v) => r.velocity = new Vector3(v.x, v.y, r.velocity.z);
        public static void SetVelXZ(this Rigidbody r, Vector3 v) => r.velocity = new Vector3(v.x, r.velocity.y, v.z);
        public static void SetVelYZ(this Rigidbody r, Vector3 v) => r.velocity = new Vector3(r.velocity.x, v.y, v.z);

        public static Vector3 Flat(this Vector3 v) => new Vector3(v.x, 0f, v.z);
    }
}
