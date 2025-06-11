using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _delay;
    private float _currentDelay;

    private bool _canPlay;

    private void Start()
    {
        _delay = _sound.clip.length;
        _currentDelay = 0;
    }

    private void Update()
    {
        if(_currentDelay != 0)
            _currentDelay -= Time.deltaTime;

        if (_currentDelay <= 0)
            _canPlay = true;
    }

    public void PlaySound()
    {
        if (_canPlay)
        {
            _sound.Play();
            _currentDelay = _delay;
            _canPlay = false;
        }
    }
}
