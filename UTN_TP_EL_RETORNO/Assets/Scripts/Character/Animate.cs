using UnityEngine;

namespace UTN_TP.Character
{
    public class Animate : MonoBehaviour
    {
        Animator _anim;

        int _speedHash;
        int _isMovingHash;
        int _isJumpingHash;
        int _isFallingHash;
        int _isGroundedHash;
        int _isAttackingHash;

        void Awake()
        {
            _anim = GetComponent<Animator>();
        
            _speedHash = Animator.StringToHash("Speed");
            _isMovingHash = Animator.StringToHash("IsMoving");
            _isJumpingHash = Animator.StringToHash("IsJumping");
            _isFallingHash = Animator.StringToHash("IsFalling");
            _isGroundedHash = Animator.StringToHash("IsGrounded");
            _isAttackingHash = Animator.StringToHash("Attack");
        }

        public void Speed(float value) => _anim.SetFloat(_speedHash, value, 0.1f, Time.deltaTime);
        public void Moving(bool state) => _anim.SetBool(_isMovingHash, state);
        public void Jumping(bool state) => _anim.SetBool(_isJumpingHash, state);
        public void Falling(bool state) => _anim.SetBool(_isFallingHash, state);
        public void Grounded(bool state) => _anim.SetBool(_isGroundedHash, state);
        public void Attacking(bool state) => _anim.SetTrigger(_isAttackingHash);
    }
}
