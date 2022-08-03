using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    return _instance;
                }

                if (_instance == null)
                {
                    //Debug.LogError(string.Format("===== LOG: Singleton '{0}' Not Created. ", typeof(T).ToString()));
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                    singleton.name = "(singleton) " + typeof(T).ToString();
                }
            }

            return _instance;
        }
    }

    public static bool IsAvailible => _instance != null;
}