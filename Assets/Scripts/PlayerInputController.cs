using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    [Header("캐릭터 이름 관련")]
    public InputField playerNameInput;
    public GameObject NameInputPanel;
    public Text InGameNameText;

    [Header("캐릭터 선택 관련")]
    public GameObject CharacterChoicePanel;
    public GameObject MainSprite;
    public GameObject MainSprite2;
    public GameObject CharacterChoiceBtn;
    public GameObject CharacterChoiceBtn2;

    private string playerName = null;
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

    public void OnCharacterChoicePanel()
    {
        CharacterChoicePanel.SetActive(true);
    }

    public void ChoiceCharacter1()
    {
        MainSprite.gameObject.SetActive(true);
        MainSprite2.gameObject.SetActive(false);
        CharacterChoiceBtn.gameObject.SetActive(true);
        CharacterChoiceBtn2.gameObject.SetActive(false);
        CharacterChoicePanel.gameObject.SetActive(false);
    }

    public void ChoiceCharacter2()
    {
        MainSprite.gameObject.SetActive(false);
        MainSprite2.gameObject.SetActive(true);
        CharacterChoiceBtn.gameObject.SetActive(false);
        CharacterChoiceBtn2.gameObject.SetActive(true);
        CharacterChoicePanel.gameObject.SetActive(false);
    }
}
