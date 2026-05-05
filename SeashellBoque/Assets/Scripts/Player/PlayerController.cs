using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedRot;
    [SerializeField] GameObject boque;
    [SerializeField] GameObject freeLookCam;
    [SerializeField] GameObject followCam;
    [SerializeField] IrisWipeController irisWipe;
    [SerializeField] GameEventSO onFinalTaskCompleted;
    private CinemachineCamera cam;
    private CharacterController controller;
    private Vector2 move;
    private PlayerInput playerInput;
    private Inventory inventory;
    private Animator anim;
    private void Start()
    {
        cam = GetComponentInChildren<CinemachineCamera>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        inventory = GetComponent<Inventory>();
        anim = GetComponentInChildren<Animator>();

        onFinalTaskCompleted.OnRaise.AddListener(GetBoquet);

        if (speed == 0.0f)
        {
            speed = 4.0f;
        }
        if(speedRot == 0.0f)
        {
            speedRot = 5.0f;
        }
        DontDestroyOnLoad(gameObject);
        boque.gameObject.SetActive(false);
        freeLookCam.SetActive(true);
        followCam.SetActive(false);
    }
    private Vector3 GetForward()
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0f;
        forward = forward.normalized;

        return forward;
    }

    private Vector3 GetRight()
    {
        Vector3 right = cam.transform.right;
        right.y = 0f;
        right = right.normalized;

        return right;
    }
    
    public void OnMove(InputValue inputVal)
    {
        move = inputVal.Get<Vector2>();
    }
    private void Update()
    {
        Interact();

        Vector3 moveDir = (move.x * GetRight() + move.y * GetForward()).normalized;

        if (moveDir != Vector3.zero)
        {
            anim.speed = 1.0f;
            Vector3 newVel = moveDir * speed;
            controller.SimpleMove(newVel);
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speedRot * Time.deltaTime);
        }
        else
        {
            anim.speed = 0.0f;
        }
    }

    private void Interact()
    {
        Collider[] items = Physics.OverlapSphere(transform.position, 1);
        if (items.Length > 0)
        {
            foreach (var item in items)
            {
                if (item.TryGetComponent(out IInteractable interactObj))
                {
                    if (interactObj.CanInteract())
                    {
                        if (playerInput.actions["Interact"].triggered)
                        {
                            interactObj.OnInteract();
                        }
                    }
                }
            }
        }
    }

    public void AddItem(Item item)
    {
        inventory.AddItem(item);
    }

    public void GetBoquet()
    {
        
        boque.gameObject.SetActive(true);
        boque.SetActive(true);
        freeLookCam.SetActive(false);
        transform.rotation = Quaternion.identity;
        followCam.SetActive(true);
        
        irisWipe.CloseIris();
    }
}
