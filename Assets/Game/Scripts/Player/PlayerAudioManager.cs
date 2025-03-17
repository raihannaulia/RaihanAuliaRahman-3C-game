using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _footstepSfx;

    [SerializeField]
    private AudioSource _punchSfx;

    [SerializeField]
    private AudioSource _landingSfx;

    [SerializeField]
    private AudioSource _glideSfx;
    private void PlayFootstepSFX()
    {
        _footstepSfx.volume = Random.Range(0.8f, 1f);
        _footstepSfx.pitch = Random.Range(0.8f, 1.5f);
        _footstepSfx.Play();
    }

    private void PlayPunchSFX()
    {
        _punchSfx.volume = Random.Range(0.8f, 1f);
        _punchSfx.pitch = Random.Range(0.8f, 1.5f);
        _punchSfx.Play();
    }

    private void LandingSFX()
    {
        _landingSfx.Play();
    }

    public void PlayGlideSfx()
    {
        _glideSfx.Play();
    }

    public void StopGlideSfx()
    {
        _glideSfx.Stop();
    }
}