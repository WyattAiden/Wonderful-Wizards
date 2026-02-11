using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;
    [Header("------- Audio Clips -------")]
    public AudioClip GrvitySwitch;
    public AudioClip pickupleft;
    public AudioClip pickupright;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
