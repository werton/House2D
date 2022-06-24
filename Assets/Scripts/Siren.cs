using UnityEngine;
using UnityEngine.Events;

public class Siren : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isAlarmEnabled = false;
    private float _minVolume = 0.01f;
    private float _maxVolume = 1.0f;
    private float _volumeStep = 0.1f;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
        _audioSource.loop = true;
    }


    private void Update()
    {
        if (_isAlarmEnabled == true)
        {
            if (_audioSource.volume < _maxVolume)
            {
                IncreaseVolume();
            }
        }
        else
        {
            if (_audioSource.isPlaying == true)
            {

                if (_audioSource.volume > _minVolume)
                {
                    DecreaseVolume();
                }
                else
                {
                    _audioSource.Stop();
                }
            }
        }
    }

    private void IncreaseVolume()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep * Time.deltaTime);
    }
    private void DecreaseVolume()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeStep * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isAlarmEnabled = true;
            _audioSource.Play();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_isAlarmEnabled == true)
            {
                _isAlarmEnabled = false;
            }
        }
    }
}

