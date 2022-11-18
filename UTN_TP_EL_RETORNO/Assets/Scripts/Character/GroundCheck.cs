using UnityEngine;

namespace UTN_TP.Character
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] Vector3 offset;
        [SerializeField] float radius;
        [SerializeField] LayerMask layer;

        Vector3 Position => transform.position + offset;
        public bool IsGrounded => Physics.CheckSphere(Position, radius, layer);

        public LayerMask Layer => layer;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Position, radius);
        }
    }
}
