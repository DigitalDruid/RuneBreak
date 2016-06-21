using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageSelector : MonoBehaviour {

    LevelManager levelManager;

    public int _stageNumber;
    public string stageNumber { get { return _text.text; } set { _text.text = value; } }
    
    public bool locked {
        get {
            if (_stageNumber != 1) return (_stageNumber >= ProgressManager.completedLevels) || (_stageNumber > ProgressManager.levelMap.Length); else return false;
        }
    }

    public Image _image;
    public Sprite _lockSprite;
    public Sprite _unlockSprite;

    public Button _button;
    public Text _text;

    // Use this for initialization
    void Awake()
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
        Debug.Log("LevelSelector "+_text.text + " locked = " + locked);
        if (locked)
        {
            _image.sprite = _lockSprite;
            _text.text = "";
            _button.onClick.RemoveAllListeners();
        }
        else
        {
            Debug.Log("unlocking LevelSelector " + _text.text);
            _image.sprite = _unlockSprite;
            _text.text = _stageNumber.ToString();
            _button.onClick.AddListener(() => levelManager.LoadLevel(_stageNumber));
        }
    }
}
