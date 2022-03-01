using UnityEngine;
using UnityEngine.UI;
using TarodevController;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField]
    public Text gameOverText;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    private PlayerStats playerStats;
    
    [SerializeField]
    public CameraFollow playerCamera;
    
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        if (!playerStats)
        {
            playerStats = player.GetComponent<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats && playerStats.isMelted) // Player has melted
        {
            HandleDeath();
        }
        if (!player) // Player gameObject has been destroyed
        {
            if (Input.GetButtonDown("Restart") || Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void HandleDeath()
    {
        gameOverText.gameObject.SetActive(true);
        Destroy(playerStats.gameObject);
        playerCamera.transform.position = playerCamera.offset;
    }
}
