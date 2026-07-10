using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class InputManager : MonoBehaviour
{
    public GameManager gm;
    public Camera mainCamera;
    public float interactRange = 1000f;
    protected InputAction movement;
    protected InputAction click;
    protected InputAction pause;
    protected CharacterController cc;
    private Vector3 playerVelocity;
    protected Animator anim;
    [SerializeField] private bool isGrounded;

    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float gravity = -9.81f;
    public float rotationX;
    public float rotationY;
    public float sensitivity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        movement = InputSystem.actions.FindAction("Move");
        click = InputSystem.actions.FindAction("Attack");
        pause = InputSystem.actions.FindAction("Pause");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        //isGrounded = cc.isGrounded;
        InputHandle();
    }

   void FixedUpdate()
    {
        Movement();
        //Rotation();
    }

    void InputHandle()
    {
        Pause();
        Interact();
    }

    void Pause()
    {
        if (pause.WasPerformedThisFrame())
        {
            gm.PauseGame();
        }
    }

    void Movement()
    {
        if (!gm.isPaused)
        {
            isGrounded = cc.isGrounded;
            if(isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector2 moveValue = movement.ReadValue<Vector2>();
            float moveX = moveValue.x;
            float moveY = moveValue.y;
            Vector3 move = transform.right * moveX + transform.forward * moveY;
            
            cc.Move(move * Time.deltaTime * playerSpeed);
            if(moveValue != Vector2.zero)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);




            //float time = Mathf.PingPong(Time.time, 1);
//if (moveValue == Vector2.zero)
            {
  //              anim.SetFloat("isWalking", 0f);
            }
    //        else
            {
      //          anim.SetFloat("isWalking", 1f);
            }
            
                //anim.SetFloat("isWalking", moveValue.x);
                //Debug.Log("Moving: " + moveValue);
                //rb.MovePosition(rb.position + new Vector3(moveValue.x, 0, moveValue.y) * time);
            
        }
    }


    void Rotation()
    {
        Vector2 mousePos = Mouse.current.delta.ReadValue();
        rotationX += mousePos.y * -1 * sensitivity;
        rotationY += mousePos.x  * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0f);
    }

    void Interact()
    {
        if (!gm.isPaused)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            //Debug.Log("Mouse Position: " + mousePos);
            if (click.WasPerformedThisFrame())
            {

                Ray ray = mainCamera.ScreenPointToRay(mousePos);//Can no longer use Input.mousePosition, need to use InputSystem instead

                if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);
                    Interactable target = hit.collider.GetComponent<Interactable>();
                    if (target != null)
                    {
                        target.ReturnAnswer();
                    }
                }
                //Debug.Log("Attack");
            }
        }
    }
}
