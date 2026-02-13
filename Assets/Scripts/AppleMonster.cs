using Unity.VisualScripting;
using UnityEngine;

public class AppleMonster : MonoBehaviour, EventInterface
{
    public int applesToEat = 3;
    public GameObject water;
    private float deathTimer = 0;
    public float deathDuration = 1f;
    private bool isDead;

    public ParticleSystem eatParticles;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnInteract(PlayerController player)
    {
        if (player.itemHolding != null && player.itemHolding.name == "Apple(Clone)")
        {
            applesToEat -= 1;
            Debug.Log("Apple Eaten");
            Destroy(player.itemHolding);
            player.itemHolding = null;
            eatParticles.Play();
        }
        else
        {
            player.dead = true;
            eatParticles.Play();
        }
        audioManager.PlaySFX(audioManager.MonApEat);
    }

    private void Update()
    {
        if (applesToEat <= 0)
        {
            if (!isDead) deathTimer += Time.deltaTime;

            if (deathTimer > deathDuration & !isDead)
            {
                gameObject.SetActive(false);
                water.SetActive(false);
                isDead = true;
            }
        }
    }
}
