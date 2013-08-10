using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public ResourceManager resourceManger { get; private set;}

    private GameManager() {}

    void Awake()
    {
        //destroy the gameobject if we alreay have an instance of the gameManager
        if (_instance != null) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        resourceManger = gameObject.AddComponent<ResourceManager>();
    }

    public static GameManager GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
                if (!_instance) _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }
}
