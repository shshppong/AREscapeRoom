using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettingManager : MonoBehaviour
{
    GameObject settingPanel;
    public Slider[] sliders;
    public InputField[] InFs;

    bool isEnable;

    void Start()
    {
        StartSettingBGVolume(GamePlayManager.Instance.backgroundAudioValue);
        StartSettingSEVolume(GamePlayManager.Instance.soundEffectValue);
    }

    public void ChangeBGInFValue()
    {
        int tmp = int.Parse(InFs[0].text);
        sliders[0].value = tmp;
    }
    public void ChangeBGSliderValue()
    {
        int tmp = (int)sliders[0].value;
        InFs[0].text = tmp.ToString();
    }
    void StartSettingBGVolume(float _value)
    {
        sliders[0].value = _value;
        InFs[0].text = _value.ToString();
    }

    public void ChangeSEInFValue()
    {
        int tmp = int.Parse(InFs[1].text);
        sliders[1].value = tmp;
    }
    public void ChangeSESliderValue()
    {
        int tmp = (int)sliders[1].value;
        InFs[1].text = tmp.ToString();
    }
    void StartSettingSEVolume(float _value)
    {
        sliders[1].value = _value;
        InFs[1].text = _value.ToString();
    }
}
