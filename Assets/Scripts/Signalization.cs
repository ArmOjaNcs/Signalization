using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private const float MaxVolume = 1; 
    private const float MinStep = 0.1f;

    private AudioSource _audioSource;
    private bool _isPlayerInside;

    private void Start()
    {
        _isPlayerInside = false;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ChangeVolume(_isPlayerInside);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player _))
            _isPlayerInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player _))
            _isPlayerInside = true;
    }

    private void ChangeVolume(bool isPositive)
    {
        float step = isPositive ? MinStep : -MinStep;
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, MaxVolume, step * Time.deltaTime);
    }
}
