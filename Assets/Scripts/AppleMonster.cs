using Unity.VisualScripting;
using UnityEngine;

public class AppleMonster : MonoBehaviour
{
    public int applesToEat = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Apple" || collision.gameObject.name == "Apple (1)" 
        || collision.gameObject.name == "Apple (2)" || collision.gameObject.name == "Apple (3)")
        {
            applesToEat -= 1;
            Debug.Log("Apple Eaten");
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (applesToEat <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
