using UnityEngine;
using UTN_TP.Character;

namespace UTN_TP.GameManagement
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject optionsMenu;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject backGround;
    
        GameObject _canvas;
        GameObject _mainMenu;
        GameObject _optionsMenu;
        GameObject _pauseMenu;
        
    
        void Awake()
        {
            _canvas = GameObject.FindGameObjectWithTag("Canvas");
            _mainMenu = Instantiate(mainMenu, _canvas.transform);
            _optionsMenu = Instantiate(optionsMenu, _canvas.transform);
            _pauseMenu = Instantiate(pauseMenu, _canvas.transform);
        
            GameManager.OnGameStateChanged += GameManagerOnStateChanged;
        }

        void GameManagerOnStateChanged(GameState state)
        {
            _mainMenu.SetActive(state == GameState.MainMenu);
            _optionsMenu.SetActive(state == GameState.Options);
            _pauseMenu.SetActive(state == GameState.Pause);
            backGround.SetActive(state != GameState.Play);
            if (state == GameState.Play)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void PlayPressed()    => GameManager.Instance.UpdateGameState(GameState.Play);
        public void OptionsPressed() => GameManager.Instance.UpdateGameState(GameState.Options);
        public void BackPressed()    => GameManager.Instance.Back();

        public void QuitPressed()    => GameManager.Instance.UpdateGameState(GameState.Quit);
    }
}
