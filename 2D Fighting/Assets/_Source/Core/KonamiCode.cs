using UISystem;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private int _index = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_index == 0 || _index == 1)
                _index++;
            else
                _index = 0;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_index == 2 || _index == 3)
                _index++;
            else
                _index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_index == 5 || _index == 7)
                _index++;
            else
                _index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_index == 4 || _index == 6)
                _index++;
            else
                _index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (_index == 8)
                _index++;
            else
                _index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (_index == 9)
            {
                SoundSystem
                    .SoundSingleton
                    .Instance
                    .PlayOneShotPlayer(SoundSystem.SoundSingleton.Instance.SoundSo.PlayerSecret);
                _enemyHealth.DealSecretDamage(10000);
                enabled = false;
            }
            else
                _index = 0;
        }

        if (Input.anyKeyDown
            && !Input.GetKeyDown(KeyCode.DownArrow)
            && !Input.GetKeyDown(KeyCode.UpArrow)
            && !Input.GetKeyDown(KeyCode.LeftArrow)
            && !Input.GetKeyDown(KeyCode.RightArrow)
            && !Input.GetKeyDown(KeyCode.B)
            && !Input.GetKeyDown(KeyCode.A))
            _index = 0;
    }
}
