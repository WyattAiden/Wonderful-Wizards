using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;
    [Header("------- Audio Clips -------")]
    public AudioClip GrvitySwitch;
    public AudioClip pickup;
    public AudioClip teleportOb;
    public AudioClip DoorOpen;
    public AudioClip DoorClose;
    public AudioClip MonApEat;
    public AudioClip Switch;
    public AudioClip PresurePlate;
    public AudioClip Water;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
