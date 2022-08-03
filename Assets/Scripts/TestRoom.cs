using UnityEngine;

public class TestRoom : MonoBehaviour
{
    private Scarecrow _currentEnemy;

    private void Start()
    {
        CreateEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_currentEnemy)
                _currentEnemy.Restore();
            else
                CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        _currentEnemy = ObjectLibrary.Instance.CreateScarecrow();
    }
}
