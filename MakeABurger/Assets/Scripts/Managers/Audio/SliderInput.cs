using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Slider portion of the SliderInput Script given by Shaped by Rain Studios. Link to Youtube video: https://www.youtube.com/watch?v=rcBHIOjZDpk
public enum VolumeType
{
   MASTER,
   AMBIENT,
   MUSIC,
   SFX,
   NONE
}

public class SliderInput : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] VolumeType type;

    [SerializeField] Slider _slider;
    [SerializeField] TMP_InputField _inputField;

    private void Awake()
    {
        _slider = this.GetComponentInChildren<Slider>();
        _inputField = this.GetComponentInChildren<TMP_InputField>();

        SetUpSliderInput();
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case VolumeType.MASTER:
                {
                    _slider.value = AudioManager.Instance.masterVolume;
                    break;
                }
            case VolumeType.AMBIENT:
                {
                    _slider.value = AudioManager.Instance.ambientVolume;
                    break;
                }
            case VolumeType.MUSIC:
                {
                    _slider.value = AudioManager.Instance.musicVolume;
                    break;
                }
            case VolumeType.SFX:
                {
                    _slider.value = AudioManager.Instance.sfxVolume;
                    break;
                }
        }
    }

    public void OnSliderValueChanged()
    {
        switch (type)
        {
            case VolumeType.MASTER:
                {
                    AudioManager.Instance.masterVolume = _slider.value;
                    break;
                }
            case VolumeType.AMBIENT:
                {
                    AudioManager.Instance.ambientVolume = _slider.value;
                    break;
                }
            case VolumeType.MUSIC:
                {
                    AudioManager.Instance.musicVolume = _slider.value;
                    break;
                }
            case VolumeType.SFX:
                {
                    AudioManager.Instance.sfxVolume = _slider.value;
                    break;
                }
        }

        MatchInputFieldToSlider(_slider.value);
    }

    public void OnInputFieldValueChange()
    {
        if (isParsible(_inputField.text) == false)
        {
            return;
        }

        float parsedVolume = float.Parse(_inputField.text) / 100f;

        switch (type)
        {
            case VolumeType.MASTER:
                {
                    AudioManager.Instance.masterVolume = parsedVolume;
                    break;
                }
            case VolumeType.AMBIENT:
                {
                    AudioManager.Instance.ambientVolume = parsedVolume;
                    break;
                }
            case VolumeType.MUSIC:
                {

                    AudioManager.Instance.musicVolume = parsedVolume;
                    break;
                }
            case VolumeType.SFX:
                {
                    AudioManager.Instance.sfxVolume = parsedVolume;
                    break;
                }
        }

        MatchSliderToInputField(_inputField.text);
    }

    void MatchInputFieldToSlider(float sliderValue)
    {
        float displayValue = sliderValue * 100f;

        if (_inputField.contentType != TMP_InputField.ContentType.DecimalNumber)
        {
            _inputField.text = string.Format("{0:F0}", displayValue);

            return;
        }

        if (Mathf.Approximately(displayValue, Mathf.Floor(displayValue)))
        {
            _inputField.text = string.Format("{0:F0}", displayValue);
        }
        else
        {
            _inputField.text = string.Format("{0:F2}", displayValue);
        }
    }

    void MatchSliderToInputField(string inputFieldValue)
    {
        if (isParsible(inputFieldValue) == true)
        {
            float parsedValue = float.Parse(inputFieldValue);

            parsedValue /= 100f;

            _slider.value = parsedValue;
        }
    }

    bool isParsible(string text)
    {
        if (float.TryParse(text, out float result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetUpSliderInput()
    {
        #region SLIDER
        _slider.onValueChanged.RemoveAllListeners();

        _slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        #endregion

        #region INPUT_FIELD
        _inputField.onValueChanged.RemoveAllListeners();

        _inputField.onValueChanged.AddListener(delegate { OnInputFieldValueChange(); });
        #endregion
    }
}
