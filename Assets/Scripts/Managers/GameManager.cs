using System.Resources;
using Assets.Scripts.Managers;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public ResourceManager ResourceManger { get; private set;}
    public GUIManager NotificationManager { get; private set; }
    public GameEventManager GameEventManager { get; private set; }
    public GUIManager GuiManager { get; private set; }
    public PeopleManager PeopleManager { get; private set; }

    //prefabs
    public GameObject person;

    private GameManager() {}

    void Awake()
    {
        //destroy the gameobject if we alreay have an instance of the gameManager
        if (_instance != null) Destroy(gameObject);

        GameEventManager = gameObject.AddComponent<GameEventManager>();
        NotificationManager = gameObject.AddComponent<GUIManager>();
        ResourceManger = gameObject.AddComponent<ResourceManager>();
        GuiManager = gameObject.AddComponent<GUIManager>();
        PeopleManager = gameObject.AddComponent<PeopleManager>();

        DontDestroyOnLoad(gameObject);
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
