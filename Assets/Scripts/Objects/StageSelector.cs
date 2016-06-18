using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelector : MonoBehaviour {

    LevelManager levelManager;

    public int _stageNumber;
    public string stageNumber { get { return _text.text; } set { _text.text = value; } }
    
    public bool locked { get { return (_stageNumber != 1 && _stageNumber > ProgressManager.completedLevels); } }

    public Image _image;
    public Sprite _lockSprite;
    public Sprite _unlockSprite;

    public Button _button;
    public Text _text;

    // Use this for initialization
    void Start()
    {
        levelManager = GameManager.instance.levelManager;
        Init();
    }
    public void Init()
    {
        if (!_image)  _image  = GetComponent<Image>();
        if (!_button) _button = GetComponent<Button>();
        if (!_text)   _text   = GetComponentInChildren<Text>();

        stageNumber = (_stageNumber > 0) ? _stageNumber.ToString() : "";

        SetLockState();
    }
    void cleanup()
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(()=> levelManager.LoadLevel(_stageNumber) );
    }
    void SetLockState()
    {
        if (locked)
        {
            _image.sprite = _lockSprite;
            _text.text = "";
            _button.onClick.RemoveAllListeners();
        }
        else
        {
            _image.sprite = _unlockSprite;
            _text.text = _stageNumber.ToString();
            _button.onClick.AddListener(() => levelManager.LoadLevel(_stageNumber));
        }
    }
}
