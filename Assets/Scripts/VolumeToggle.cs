using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private MixerGroups _mixerGroup;

    private Toggle _toggle;
    private string _group;

    private void Start()
    {
        _group = _mixerGroup.ToString();
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(ToggleVolume);
    }

    private void OnDestroy()
    {
        _toggle.onValueChanged.RemoveListener(ToggleVolume);
    }

    private void ToggleVolume(bool enabled)
    {
        _mixer.audioMixer.SetFloat(_group, enabled ? 0 : -80);
    } 
}
