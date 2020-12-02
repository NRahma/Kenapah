using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 4f;

    private Transform cameraMain;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Player playerInput;
    private Transform child;
    private Animator anim;
    private bool isRunning, isJumping;

    public AudioSource targetSound, runningSound;
    public GameObject completedPanel;
    public Text score;
    int scores = 0;
    int collected = 0;

    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }


    private void Start()
    {
        cameraMain = Camera.main.transform;
        child = transform.GetChild(0).transform;
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (playerInput.PlayerMain.Jump.triggered && groundedPlayer && !isJumping)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
        }
        else if (!playerInput.PlayerMain.Jump.triggered && !groundedPlayer && isJumping)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        if (move != Vector3.zero && !isRunning)
        {
            isRunning = true;
            anim.SetBool("isRunning", isRunning);

            runningSound.Play();
        }
        else if (move == Vector3.zero && isRunning)
        {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);

            runningSound.Stop();
        }

        if (collected == 12)
        {
            completedPanel.SetActive(true);
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Target"))
        {
            Destroy(collider.gameObject);
            scores += 25;
            collected += 1;
            score.text = scores.ToString();

            targetSound.Play();
        }
    }

}
