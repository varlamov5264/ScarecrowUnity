using UnityEngine;

//В идеале хотелось бы избавиться от синглтона и для каждого типа объектов сделать свою фабрику
public class ObjectFactory : Singleton<ObjectFactory>
{
    [SerializeField] private Scarecrow _scarecrow;
    [SerializeField] private Weapons.Bullet _bullet;

    public Scarecrow CreateScarecrow() => CreateObject(_scarecrow);

    public Weapons.Bullet CreateBullet() => CreateObject(_bullet);

    private T CreateObject<T>(T _prefab) where T : MonoBehaviour
    {
        var obj = Instantiate(_prefab);
        obj.gameObject.SetActive(true);
        return obj;
    }
}