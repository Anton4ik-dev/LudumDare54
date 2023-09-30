using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private UISwitcher uISwitcher;

        [SerializeField] private Button firstLevelButton;
        [SerializeField] private int firstLevelId;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            firstLevelButton.onClick.AddListener(() => SceneManager.LoadScene(firstLevelId));
        }
    }
}