using System.Resources;
using Assets.Scripts.Managers;
using Assets.Scripts.Misc;
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
    public DayManager DayManager { get; private set; }
    public GameTimer GameTimer { get; private set; }

    //prefabs
    public GameObject person;

    private GameManager() {}

    public T[] GetGameObjectsOfType<T>()
    {
        return FindObjectsOfType(typeof(T)) as T[];
    }

    void Awake()
    {
        //destroy the gameobject if we alreay have an instance of the gameManager
        if (_instance != null) Destroy(gameObject);

        GameEventManager = gameObject.AddComponent<GameEventManager>();
        NotificationManager = gameObject.AddComponent<GUIManager>();
        ResourceManger = gameObject.AddComponent<ResourceManager>();
        GuiManager = gameObject.AddComponent<GUIManager>();
        PeopleManager = gameObject.AddComponent<PeopleManager>();
        DayManager = gameObject.AddComponent<DayManager>();
        GameTimer = gameObject.AddComponent<GameTimer>();

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
