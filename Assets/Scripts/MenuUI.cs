using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public Button playButton;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playButton.onClick.AddListener(LoadNextScene); 
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("FiringRange");
        spawnManager.Start();
    }
    
}
