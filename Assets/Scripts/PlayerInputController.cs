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
    public GameObject CharacterChoiceBg;
    public GameObject CharacterChoiceBtn;
    public GameObject CharacterChoiceBtn2;

    public RectTransform NamePanel;
    public RectTransform InputImage;

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

    public void OnInputNamePanel()
    {
        InputImage.gameObject.SetActive(true);
        NameInputPanel.gameObject.SetActive(true);
        NamePanel.sizeDelta = new Vector2(800, 500);
        InputImage.anchoredPosition = new Vector2(0, -20);
        playerNameInput.text = null;
        CharacterChoiceBg.gameObject.SetActive(false);
    }

    public void OnCharacterChoicePanel()
    {
        CharacterChoicePanel.SetActive(true);
    }

    public void OnCharacterChoicePanel2()
    {
        NameInputPanel.gameObject.SetActive(true);
        NamePanel.sizeDelta = new Vector2(0, 0);
        CharacterChoicePanel.SetActive(true);
        InputImage.gameObject.SetActive(false);
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
