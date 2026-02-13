using UnityEngine;
using UnityEngine.SceneManagement;
public class RestaurtGame : MonoBehaviour, EventInterface
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void OnInteract(PlayerController player)
    {
        RestartGame();
    }

    void RestartGame()
    {
        foreach (PlayerController playah in GameMan.Players)
        {
            Destroy(playah.gameObject);
        }
        GameMan.Players.Clear();
        SceneManager.LoadScene("LevelOne");
    }


}
