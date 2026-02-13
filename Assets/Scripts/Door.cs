using UnityEngine;
public class Door : MonoBehaviour, EventInterface
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Collider2D Collider;
    [SerializeField] private bool isOn = true;
    [SerializeField] public bool isWinDoor;
    [SerializeField, Tooltip("Only needs to be defined for win door")] public int keysToUnlock = 3;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (!isOn)
        {
            Collider.enabled = false;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 0.3f);
        }
        if (isWinDoor)
        {
            if (keysToUnlock <= 0)
            {
                OpenDoor();
                
            }
        }
    }
    public void OnInteract(PlayerController player)
    {
        if (player.itemHolding == null) return;

        Key key = player.itemHolding.GetComponent<Key>();

        if (key != null && !isWinDoor)
        {
            Debug.Log("Door opened with key");

            OpenDoor();
            audioManager.PlaySFX(audioManager.DoorOpen);
        }

        else if (key != null && isWinDoor)
        {
            keysToUnlock-= 1;
            Debug.Log(keysToUnlock + " more keys are needed to unlock the door");
            Destroy(player.itemHolding);
            audioManager.PlaySFX(audioManager.DoorOpen);
        }

        else
        {
            Debug.Log("Item Held Is Not Key");
           
        }
        
    }

    void OpenDoor()
    {
        isOn = false;
    }
}
