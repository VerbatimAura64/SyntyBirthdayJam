using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameManager gm;
    public Camera mainCamera;
    public float interactRange = 1000f;
    protected InputAction movement;
    protected InputAction click;
    protected InputAction pause;
    protected Rigidbody rb;
    [SerializeField]
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        movement = InputSystem.actions.FindAction("Move");
        click = InputSystem.actions.FindAction("Attack");
        pause = InputSystem.actions.FindAction("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        InputHandle();
    }

   void FixedUpdate()
    {
        Movement();
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
            float time = Mathf.PingPong(Time.time, 1);
            Vector2 moveValue = movement.ReadValue<Vector2>();
            if (moveValue != Vector2.zero)
            {
                //Debug.Log("Moving: " + moveValue);
                rb.MovePosition(rb.position + new Vector3(moveValue.x, 0, moveValue.y) * time);
            }
        }
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
