using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UIManager _uIManager;

    private Animator anim;
    private CharacterController characterController;
    private CapsuleCollider capsuleCollider;
    private Vector3 dir;

    [SerializeField] private float speed;
    private float _maxSpeed ;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int lineToMove = 1;
    private float lineDistance = 6;
    public static float currentTimeScale = 1f;

    private bool isSliding;
    public static bool isplay;

    private void Start()
    {
        _maxSpeed = 24.9f;
        speed = 20f;
        _uIManager.StartGameEvent += StartSpeedcounter;
        Application.targetFrameRate = 60;
        currentTimeScale = 1f;
        capsuleCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1;
        characterController = GetComponent<CharacterController>();
        anim.SetBool("isDancing", true);
        CollisionDetector.OnCollisionDeathEvent += DeathAnimation;
    }

    private void Update()
    {
        Debug.Log("timeDebug:" + Time.timeScale);
        if(isplay)
        {
            anim.SetBool("isDancing", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);    
            InputSwipe();

            if (characterController.isGrounded && !isSliding)
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);

            if (characterController.isGrounded && !isSliding)
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (lineToMove == 0)
                targetPosition += Vector3.left * lineDistance;
            else if (lineToMove == 2)
                targetPosition += Vector3.right * lineDistance;

            if (transform.position == targetPosition)
                return;
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                characterController.Move(moveDir);
            else
                characterController.Move(diff);
        }
    }

    private void FixedUpdate()
    {   
        if (isplay)
        {
            Muving();
        }
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDeathEvent -= DeathAnimation;
        _uIManager.StartGameEvent -= StartSpeedcounter;
    }

    private void StartSpeedcounter(GameObject gameObject)
    {
        StartCoroutine(SpeedUp());
    }

    private IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(0.5f);
        if (_maxSpeed > speed)
        {
            speed += 0.1f;
            Debug.Log("speed " + speed);
            StartCoroutine(SpeedUp());
        }
    }

    private void InputSwipe()
    {
        if (SwipeController.swipeRight)
        {
            AudioManager.Instance.PlaySFX("Slide");
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }
        if (SwipeController.swipeLeft)
        {
            AudioManager.Instance.PlaySFX("Slide");
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }
        if (SwipeController.swipeUp)
        {
            AudioManager.Instance.PlaySFX("Slide");
            if (characterController.isGrounded)
            {
                Jump();
            }
        }
        if (SwipeController.swipeDown)
        {
            AudioManager.Instance.PlaySFX("Slide");
            StartCoroutine(Slide());
        }
    }

    public void Muving()
    {
        dir.y += gravity * Time.fixedDeltaTime;
        dir.z = speed;
        characterController.Move(dir * Time.fixedDeltaTime);
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.fixedDeltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            characterController.Move(moveDir);
        else
            characterController.Move(diff);
    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetTrigger("Jump");
    }
    private IEnumerator Slide()
    {
        capsuleCollider.enabled= false;
        characterController.center = new Vector3(0f, 0.7f, 0f);
        characterController.height = .9f;
        isSliding = true;
        anim.SetBool("isRunning", false);
        anim.SetTrigger("Roll");

        yield return new WaitForSeconds(0.9f);
        capsuleCollider.enabled = true; 
        characterController.center = new Vector3(0, 2.4f, 0);
        characterController.height = 4.9f;
        isSliding = false;
    }

    private void DeathAnimation(GameObject gameObject)
    {
        anim.SetBool("Death", true);
    }
}
 