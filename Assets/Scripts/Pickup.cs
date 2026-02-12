using UnityEngine;

public class Pickup : MonoBehaviour, EventInterface
{
    public bool isMirror = false;
    public bool isPickedUp = false;

    public void OnInteract(PlayerController player)
    {
        if (isPickedUp == false)
        {
            GravBall gravball = GetComponent<GravBall>();
            if (gravball != null)
            {
                gravball.flipSideGravity(player);
            }

            Debug.Log(player.name + player.playerNumber + " picked up " + gameObject.name);

            transform.SetParent(player.transform); //Parent object to player

            transform.localPosition = Vector3.zero; //Reset position

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            player.itemHolding = this;
            isPickedUp = true;

        }

        else
        {
            GravBall gravball = GetComponent<GravBall>();
            if (gravball != null)
            {
                gravball.flipSideGravity(player);
            }

            Debug.Log(player.name + player.playerNumber + " dropped " + gameObject.name);

            transform.SetParent(null); //Parent object to player

            transform.localPosition = new Vector3 (player.rb2d.position.x - 0.8f, player.rb2d.position.y); //Reset position

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = true;
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            player.itemHolding = null;
            isPickedUp = false;
        }
        
    }
    public void SendThroughHole(GameObject pairedHole, PlayerController Player)
    {
        GravBall gravball = GetComponent<GravBall>();
        if (gravball != null)
        {
            gravball.flipSideGravity(Player);
        }

        isMirror = !isMirror; 

        transform.SetParent(null); //Parent object to player

        transform.localPosition = pairedHole.transform.position;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = true;
        }

        Player.itemHolding = null;
        isPickedUp = false;
        Debug.Log("Object goes through hole");
    }
}
