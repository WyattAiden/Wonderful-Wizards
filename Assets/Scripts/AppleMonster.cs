using Unity.VisualScripting;
using UnityEngine;

public class AppleMonster : MonoBehaviour
{
    public int applesToEat = 3;
    public GameObject water;
    private float deathTimer = 0;
    public float deathDuration = 1f;
    private bool isDead;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Apple" || collision.gameObject.name == "Apple (1)" 
        || collision.gameObject.name == "Apple (2)" || collision.gameObject.name == "Apple (3)")
        {
            applesToEat -= 1;
            Debug.Log("Apple Eaten");
            Destroy(collision.gameObject);
            
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
