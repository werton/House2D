using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    private readonly float _minVolume = 0.01f;
    private readonly float _maxVolume = 1.0f;
    private readonly float _volumeStep = 0.1f;
    private AudioSource _audioSource;
    private Coroutine _increaseVolumeCoroutine;
    private Coroutine _decreaseVolumeCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
        _audioSource.loop = true;
    }

    private void Update()
    {
    }

    private IEnumerator IncreaseVolumeToMax()
    {
        while (_audioSource.volume < _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolumeToStop()
    {
        while (_audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeStep * Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            if (_decreaseVolumeCoroutine != null)
            {
                StopCoroutine(_decreaseVolumeCoroutine);
            }

            _increaseVolumeCoroutine = StartCoroutine(IncreaseVolumeToMax());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_increaseVolumeCoroutine != null)
            {
                StopCoroutine(_increaseVolumeCoroutine);
            }

            _decreaseVolumeCoroutine = StartCoroutine(DecreaseVolumeToStop());
        }
    }
}