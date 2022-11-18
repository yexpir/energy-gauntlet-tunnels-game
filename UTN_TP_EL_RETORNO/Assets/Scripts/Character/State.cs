using UnityEngine;

namespace UTN_TP.Character
{
    public class State : MonoBehaviour
    {
        GroundCheck _groundCheck;

        void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            _groundCheck = GetComponent<GroundCheck>();
        }

        void Update()
        {
            IsGoingUp = Velocity.y > 1;
            IsGrounded = _groundCheck.IsGrounded && !IsGoingUp;
            IsMoving = Velocity.Flat().magnitude > 0.01f;
            IsLanding = IsGrounded;
            IsJumping = IsGoingUp || !IsLanding && IsJumping;
            IsFlipping = IsGoingUp && IsJumping;
            IsFalling = Velocity.y < -1f && !IsGrounded;
            IsFallingFast = (IsJumping ? Velocity.y < 2.0f : Velocity.y < -10f) && !IsGrounded;
        }


        public bool IsMoving { get; private set; }
        public bool IsGoingUp { get; private set; }
        public bool IsJumping { get; private set; }
        public bool IsFlipping { get; private set; }
        public bool IsFalling { get; private set; }
        public bool IsFallingFast { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsLanding
        {
            get => _isLanding;
            private set
            {
                if (!value)
                {
                    _hasLanded = false;
                }
                if (!_hasLanded && value)
                {
                    _isLanding = true;
                    _hasLanded = true;
                }
                else
                {
                    _isLanding = false;
                }
            }
        }bool _isLanding; bool _hasLanded;


        public Rigidbody Rb { get; private set; }
        public Vector3 Velocity => Rb.velocity;
        public float Speed => IsMoving ? Velocity.Flat().magnitude : 0;

        public LayerMask GroundLayer => _groundCheck.Layer;
    }
}
