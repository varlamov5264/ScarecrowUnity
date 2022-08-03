using UnityEngine;

public class ObjectLibrary : Singleton<ObjectLibrary>
{
    [SerializeField] private Scarecrow _scarecrow;
    [SerializeField] private Bullet _bullet;

    public Scarecrow CreateScarecrow() => CreateObject(_scarecrow);

    public Bullet CreateBullet() => CreateObject(_bullet);

    private T CreateObject<T>(T _prefab) where T: MonoBehaviour
    {
        var obj = Instantiate(_prefab);
        obj.gameObject.SetActive(true);
        return obj;
    }
}
