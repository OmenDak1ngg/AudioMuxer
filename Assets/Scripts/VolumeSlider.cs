using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private MixerGroups _mixerGroup;
    [SerializeField] private AudioMixerGroup _mixer;

    private Slider _slider;
    private string _group;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _group = _mixerGroup.ToString();

        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        _mixer.audioMixer.SetFloat(_group, Mathf.Log10(volume) * 20);
    }
}
