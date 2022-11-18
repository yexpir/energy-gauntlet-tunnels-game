using UnityEngine;

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

        private void GameManagerOnStateChanged(GameState state)
        {
            print(state);
            _mainMenu.SetActive(state == GameState.MainMenu);
            _optionsMenu.SetActive(state == GameState.Options);
            _pauseMenu.SetActive(state == GameState.Pause);
            //backGround.SetActive(state != GameState.Play);
        }

        public void PlayPressed()    => GameManager.Instance.UpdateGameState(GameState.Play);
        public void OptionsPressed() => GameManager.Instance.UpdateGameState(GameState.Options);
        public void BackPressed()    => GameManager.Instance.UpdateGameState(GameManager.Instance.previousState);
        public void ExitPressed()    => GameManager.Instance.UpdateGameState(GameState.Exit);
    }
}
