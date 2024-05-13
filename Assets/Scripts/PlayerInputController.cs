using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    public InputField playerNameInput;
    private string playerName = null;

    public GameObject NameInputPanel;
    public Text InGameNameText;

    private void Awake()
    {
        camera = Camera.main;
        playerName = playerNameInput.GetComponentInChildren<InputField>().text;
    }

    private void Update()
    {
        playerName = playerNameInput.text;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputName();
        }

    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void InputName()
    {
        if (playerName.Length >= 2 && playerName.Length <= 10)
        {
            InGameNameText.text = playerName;
            NameInputPanel.gameObject.SetActive(false);
        }
    }
}
