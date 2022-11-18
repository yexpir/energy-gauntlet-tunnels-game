using UnityEngine;

namespace UTN_TP.Character
{
    public class Action : MonoBehaviour
    {
        PlayerData _data;
        State _state;
        RigHandler _rig;
    
        float _moveSpeed;

        Quaternion _lookRotation;
        float _lookAtTime;

        void Awake()
        {
            _data = GetComponent<PlayerData>();
            _state = GetComponent<State>();
            _rig = GetComponent<RigHandler>();
            
            SetGravity(_data.fallGravity);
        }

        public void Move(Vector3 direction, Rigidbody actor)
        {
            var v = direction.normalized * (_moveSpeed * Time.deltaTime);
            if(!_state.IsGoingUp)
                SmoothLookAt(actor.velocity.Flat().magnitude > 0.5f ? actor.velocity.Flat() : direction);
            actor.SetVelXZ(v);
        }

        public void Walk() => _moveSpeed = _data.walkSpeed;

        public void Run() => _moveSpeed = _data.runSpeed;

        public void Jump(Rigidbody actor)
        {
            _rig.KillPunchRoutine();
            actor.SetVelY(_data.jumpForce);
        }

        public void Attack()
        {
            if(_state.IsFlipping) return;
            _rig.Punch();
        }

        static void SetGravity(float gravity) => Physics.gravity = Vector3.down * Mathf.Abs(gravity);

        public void SmoothLookAt(Vector3 direction)
        {
            if(direction == Vector3.zero) return;
            _lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, _lookAtTime);
            _lookAtTime = Time.deltaTime * _data.rotationSpeed;
        }
    }
}
