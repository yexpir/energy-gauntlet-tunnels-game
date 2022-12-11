using UnityEngine;
using UTN_TP.GameManagement;

namespace UTN_TP.Character
{
    public class PlayerController : MonoBehaviour
    {
        Control _control;
        State _state;
        Action _action;
        Animate _animate;

        Ray _ray;
        RaycastHit _hit;
   
        void Awake()
        {
            _control = GetComponent<Control>();
            _state = GetComponent<State>();
            _action = GetComponent<Action>();
            _animate = GetComponent<Animate>();
        
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }

        void Update()
        {
            _animate.Moving(_state.IsMoving);
            _animate.Speed(_state.Speed);
            _animate.Falling(_state.IsFallingFast);
            if (_state.IsLanding)
            {
                _animate.Grounded(true);
                _animate.Jumping(false);
            }
            else if(_state.IsGoingUp)
                _animate.Grounded(false);
            
            
            if(Input.GetKeyDown(KeyCode.Escape)) GameManager.Instance.UpdateGameState(GameState.Pause);
        }

        void FixedUpdate()
        {
            HandleMove();
            HandleRun();
            HandleJump();
            HandleAttack();
        }

        void HandleMove()
        {
            _action.Move(_control.Direction, _state.Rb);
        }
        void HandleRun()
        {
            if (_control.ShouldRun) _action.Run();
            else _action.Walk();
        }
        void HandleJump()
        {
            if(!_state.IsGrounded) _control.ResetJumpInput();
            if (_control.ShouldJump && _state.IsGrounded)
            {
                _action.Jump(_state.Rb);
                _animate.Jumping(true);
                _control.ResetJumpInput();
            }
        }
        void HandleAttack()
        {
            if (!_control.ShouldAttack) return;
            _action.Attack();
            _animate.Attacking(true);
            _control.ResetAttackInput();
        }
    }
}
