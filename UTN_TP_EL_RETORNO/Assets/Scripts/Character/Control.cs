using UnityEngine;

namespace UTN_TP.Character
{
    public class Control : MonoBehaviour
    {
        Camera _cam;
        void Awake()
        {
            _cam = Camera.main;
        }
        void Update()
        {
            Direction = CamRight * Input.GetAxisRaw("Horizontal") + CamForward * Input.GetAxisRaw("Vertical");
            ShouldRun = Input.GetButton("Run");
            ShouldJump = !ShouldJump ? Input.GetButtonDown("Jump"): ShouldJump; 
            ShouldAttack = !ShouldAttack ? Input.GetButtonDown("Fire1") : ShouldAttack;
        }

        public Vector3 Direction { get; private set; }
        public bool ShouldRun { get; private set; }
        public bool ShouldJump { get; private set; }
        public bool ShouldAttack { get; private set; }

        public void ResetJumpInput()
        {
            ShouldJump = false;
        }
        public void ResetAttackInput()
        {
            ShouldAttack = false;
        }
    
        Vector3 CamRight => _cam.transform.right.Flat().normalized;
        Vector3 CamForward => _cam.transform.forward.Flat().normalized;
    }
}
