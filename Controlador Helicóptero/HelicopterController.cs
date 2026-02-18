using Inputs;
using UnityEngine;

public class HelicopterController : MonoBehaviour {
    
    private Rigidbody _helicopter;
    private HelicopterInput _input;
    
    public Transform MainRotor;
    public Transform TailRotor;
    private float _rotorSpeed = 0f;
    
    public float LiftCoefficient = 1.2f;
    
    private const float MaxTiltAngle = 25f;
    public AnimationCurve PowerCurve = new AnimationCurve(new Keyframe(0f,0f), new Keyframe(1f,1f));
    
    public LayerMask GroundLayer;
    private float _groundDistance;
    public bool IsGrounded = true;

    private void Start() {
        _helicopter = GetComponent<Rigidbody>();
        _input = GetComponent<HelicopterInput>();
    }
    private void FixedUpdate() {
        if (_input) {
            HandleGroundCheck();
            RotateRotors();
            ControlLift();
            ControlRestart();
            if(!IsGrounded) {
                ControlTilt();
                ControlRotation();
            }
        }
    }
    
    void HandleGroundCheck(){
        Vector3 direction = transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out var hit, 3000, GroundLayer)) {
            _groundDistance = hit.distance;
            IsGrounded = _groundDistance < 2;
        }
    }

    private void RotateRotors() {
        if (!MainRotor || !TailRotor) return;

        if (!IsGrounded) {
            _rotorSpeed = 1000f;
        } else if (LiftCoefficient <= 1.2f) {
            _rotorSpeed = 0;
        } else {
            _rotorSpeed = LiftCoefficient * 10;
        }

        MainRotor.Rotate(Vector3.up, _rotorSpeed * Time.deltaTime);
        TailRotor.Rotate(Vector3.right, _rotorSpeed * Time.deltaTime);
    }

    void ControlLift() {
        if (_input.LiftInput == 0 && LiftCoefficient > 160f) {
            LiftCoefficient = 160f;
        } else if (_input.LiftInput == 0 && LiftCoefficient < 0f) {
            LiftCoefficient = 0f;
        }

        LiftCoefficient += _input.LiftInput;
        
        float liftForce = LiftCoefficient * 0.05f * 1.225f;
        liftForce = Mathf.Clamp(liftForce, -liftForce, liftForce);
        _helicopter.AddForce(transform.up * liftForce, ForceMode.Acceleration);
    }

    private void ControlTilt() {
        Vector3 tiltDirection = new Vector3(_input.TiltInput.y, 0, _input.TiltInput.x * -1);
        float horizontalTarget = Mathf.Clamp(tiltDirection.x * MaxTiltAngle, -MaxTiltAngle, MaxTiltAngle);
        float verticalTarget = Mathf.Clamp(tiltDirection.z * MaxTiltAngle, -MaxTiltAngle, MaxTiltAngle);
        
        var targetRotation = Quaternion.Euler(horizontalTarget, transform.rotation.eulerAngles.y, verticalTarget);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, PowerCurve.Evaluate(0.5f) * Time.fixedDeltaTime);
        
        Vector3 moveDirection = transform.right * (tiltDirection.z * -1) + (transform.forward * tiltDirection.x);
        
        _helicopter.AddForce(moveDirection * 10, ForceMode.Acceleration);
    }

    private void ControlRotation() {
        if (_input.RotateInput != 0) {
            _helicopter.AddTorque(transform.up * (_input.RotateInput * _helicopter.mass * 10 * Time.fixedDeltaTime), ForceMode.Impulse);
        }
    }

    private void ControlRestart() {
        if (_input.RestartInput) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
