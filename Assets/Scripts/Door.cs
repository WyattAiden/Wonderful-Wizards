using UnityEngine;

public class Door : MonoBehaviour, EventInterface
{

    public void OnInteract(PlayerController player)
    {
        foreach //get objects in scene that are prefab "Key", eg. Key, Key(1) etc...
            //Then make a list of the key objects in scene that are prefab "Key"

        for (int i = 0; i < length; i++) //and use it to determine
        {
                if (player.itemHolding.name == ("Key (" + i + ")"))
                {

                }

        }
        


    }
}
