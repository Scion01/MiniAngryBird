using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelId = 1;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }
        Debug.Log("All enemies killed!");
        _nextLevelId++;
        string nextLevelName = "Level" + _nextLevelId.ToString();
        SceneManager.LoadScene(nextLevelName);
    }
}
