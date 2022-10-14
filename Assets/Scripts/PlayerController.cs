using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Range(3f, 10f)]
    [SerializeField] float playerSpeed = 2f;
    [Header("Screen Borders")]
    [SerializeField] float xAxisWorldBorder = 1f;
    [SerializeField] float bottomOfScreenBorder = 1f;
    [SerializeField] float topOfScreenBorder = 1f;

    [Header("Player Sprites")]
    [SerializeField] Sprite level;
    [SerializeField] Sprite leftBank;
    [SerializeField] Sprite rightBank;
    [SerializeField] GameObject sideJets;
    [SerializeField] GameObject centralJet; 

    PlayerInput playerInput;
    WeaponsController weaponsController;

    InputAction move;
    InputAction fire;
    InputAction fireHold;

    SpriteRenderer spriteRenderer;
    Camera cam;
    Rect cameraRect;
    bool controlsDisabled = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        weaponsController = GetComponent<WeaponsController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetInputActions();
        cam = Camera.main; //TODO this is hacky but will do
    }

    private void GetInputActions()
    {
        move = playerInput.actions["Move"];
        fire = playerInput.actions["Fire"];
        fireHold = playerInput.actions["FireHold"];
    }

    private void OnEnable()
    {
        fire.performed += Fire;
        fireHold.started += weaponsController.OnFireHoldStart;
        fireHold.performed += weaponsController.OnFireHoldPerformed;
    }

    private void OnDisable()
    {
        fire.performed -= Fire;
        fireHold.started -= weaponsController.OnFireHoldStart;
        fireHold.performed -= weaponsController.OnFireHoldPerformed;
    }

    private void Start()
    {
        SetupCameraRect();
    }

    private void Update()
    {
        if (controlsDisabled) { return; }

        Vector2 rawMovementInput = move.ReadValue<Vector2>();
        transform.Translate(rawMovementInput * playerSpeed * Time.deltaTime, Space.Self);

        if (rawMovementInput.x > 0)
        {
            spriteRenderer.sprite = rightBank;
            centralJet.SetActive(true);
            sideJets.SetActive(false);

        }
        else if (rawMovementInput.x < 0)
        {
            spriteRenderer.sprite = leftBank;
            centralJet.SetActive(true);
            sideJets.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = level;
            centralJet.SetActive(false);
            sideJets.SetActive(true);
        }

        ClampPlayerToCameraLimits();
    }

    public void DisableControls()
    {
        controlsDisabled = true;
        fire.performed -= Fire;
        fireHold.started -= weaponsController.OnFireHoldStart;
        fireHold.performed -= weaponsController.OnFireHoldPerformed;
    }

    public void EnableControls()
    {
        controlsDisabled = true;
        fire.performed += Fire;
        fireHold.started += weaponsController.OnFireHoldStart;
        fireHold.performed += weaponsController.OnFireHoldPerformed;
    }

    private void ClampPlayerToCameraLimits()
    {
        transform.position = new Vector3(
     Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax),
     Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax),
     transform.position.z);
    }

    private void SetupCameraRect()
    {
        var bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        var topRight = cam.ScreenToWorldPoint(new Vector3(
            cam.pixelWidth, cam.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x + xAxisWorldBorder,
            bottomLeft.y + bottomOfScreenBorder,
            topRight.x - (bottomLeft.x + (xAxisWorldBorder * 2)),
            topRight.y - bottomLeft.y - (topOfScreenBorder * 2));
    }

    private void Fire(InputAction.CallbackContext context)
    {
        weaponsController.Fire();
    }
}
