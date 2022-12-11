using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace UTN_TP.Character
{
    public class RigHandler : MonoBehaviour
    {
        [SerializeField] MultiAimConstraint _bodyAim;
        [SerializeField] MultiAimConstraint _shoulderAim;
        [SerializeField] MultiAimConstraint _armAim;
        [SerializeField] MultiAimConstraint _forearmAim;
        [SerializeField] MultiAimConstraint _handAim;
    
        [SerializeField] AnimationCurve _shoulderCurve;
        [SerializeField] AnimationCurve _armCurve;
        [SerializeField] AnimationCurve _armTargetCurve;
        [SerializeField] AnimationCurve _forearmCurve;
        [SerializeField] AnimationCurve _resetCurve;

        [SerializeField] Transform armTarget;
        [SerializeField] Transform armTargetStart;
        [SerializeField] Transform armTargetEnd;

        [SerializeField] GameObject _punch;
        

        [SerializeField] float _speed;
        Coroutine co;
        Coroutine co2;

        bool _isInterruptible;
        public void Punch()
        {
            if (co is not null && _isInterruptible)
            {
                StopCoroutine(co);
                co = StartCoroutine(PunchRoutine());
            }
            else if(co is null) co = StartCoroutine(PunchRoutine());
        }

        IEnumerator PunchRoutine()
        {
            if(co2 is not null) StopCoroutine(co2);
            var time = 0f;
            _isInterruptible = false;
            while (time < 1f)
            {
                time += _speed * Time.deltaTime;
                armTarget.position = Vector3.Lerp(armTargetStart.position, armTargetEnd.position, _armTargetCurve.Evaluate(time));
                HandlePunchHixBox(time);
                if (time > .75f) _isInterruptible = true;
                SetWeight(time);
                yield return null;
            }
            time = 1f;
            SetWeight(time);
            co2 = StartCoroutine(ResetPunchRoutine());
        }
        IEnumerator ResetPunchRoutine()
        {
            var time = 0f;
            while (time < 1f)
            {
                time += Time.deltaTime * _speed;
                ResetWeight(_resetCurve.Evaluate(time));
                yield return null;
            }
            time = 1f;
            ResetWeight(_resetCurve.Evaluate(time));
        }

        void SetWeight(float time)
        {
            _bodyAim.weight     = _shoulderCurve.Evaluate(time);
            _shoulderAim.weight = _shoulderCurve.Evaluate(time);
            _armAim.weight      = _armCurve.Evaluate(time);
            _forearmAim.weight  = _forearmCurve.Evaluate(time);
            _handAim.weight     = _forearmCurve.Evaluate(time);
        }
        void ResetWeight(float weight)
        {
            _armAim.weight      = weight;
            _forearmAim.weight  = weight;
        }
        public void KillPunchRoutine()
        {
            if(co is not null) StopCoroutine(co);
            if(co2 is not null) StopCoroutine(co2);
            _bodyAim.weight     = 0f;
            _shoulderAim.weight = 0f;
            _armAim.weight      = 0f;
            _forearmAim.weight  = 0f;
            _handAim.weight     = 0f;
        }

        void HandlePunchHixBox(float time)
        {
            _punch.SetActive(time is > .45f and <= .6f);
        }

    }
}
