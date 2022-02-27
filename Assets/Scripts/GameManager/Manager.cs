using UnityEngine;
using UnityEngine.UI;
using TarodevController;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
            

    [SerializeField]
    public Text gameOverText;
    
    [SerializeField]
    public PlayerController player;
    
    [SerializeField]
    public CameraFollow playerCamera;
    
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        if (!player)
        {
            player = GameObject.FindObjectOfType<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isMelted)
        {
            HandleDeath();
        }
        if (!player)
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
        Destroy(player.gameObject);
        playerCamera.transform.position = playerCamera.offset;
    }
}
