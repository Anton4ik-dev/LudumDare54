using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private int mainMenuId;
        [SerializeField] private int thisLevelId;
        [SerializeField] private int nextLevelId;

        public void StopTime()
        {
            Time.timeScale = 0;
        }
        public void Continue()
        {
            Time.timeScale = 1;
        }
    }
}