using UnityEngine;

public class TestRoom : MonoBehaviour
{
    private IRestorable _restorableEnemy;

    private void Start()
    {
        CreateEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_restorableEnemy.Equals(null))
                CreateEnemy();
            else
                _restorableEnemy.Restore();
        }
    }

    private void CreateEnemy()
    {
        _restorableEnemy = ObjectFactory.Instance.CreateScarecrow();
    }
}