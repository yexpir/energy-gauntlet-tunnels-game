using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UTN_TP.Character;

namespace UTN_TP.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public static event Action<GameState> OnGameStateChanged;

        private List<GameState> stateHistory = new();

        public GameState previousState;


        void Awake() => Instance = this;

        void Start() => UpdateGameState(GameState.MainMenu);

       

        public void UpdateGameState(GameState newState)
        {
            stateHistory.Add(newState); 
            if(stateHistory.Count > 2) stateHistory.RemoveAt(0);
            previousState = stateHistory[0];
        
            switch (newState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Play:
                    Play();
                    break;
                case GameState.Pause:
                    Pause();
                    break;
                case GameState.Options:
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.Win:
                    break;
                case GameState.Lose:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        
            OnGameStateChanged?.Invoke(newState);

        }
        private void Play()
        {
            if (previousState != GameState.Pause)
            {
                Loader.Add(Loader.Scenes.Controller);
                Loader.Add(Loader.Scenes.Level1);
            }
            Time.timeScale = 1;
        }

        private static void Pause() => Time.timeScale = 0;
    
        private void Exit()
        {
            if(previousState == GameState.MainMenu) Application.Quit();
            else
            {
                Loader.Reset();
            }
        }

        public void UnloadAsync(string s) => StartCoroutine(UnloadAsyncRoutine(s));
        
        private IEnumerator UnloadAsyncRoutine(string s)
        {
            var operation = Loader.UnloadAsync(s);
            while (!operation.isDone)
            {
                yield return null;
            }
            UpdateGameState(GameState.MainMenu);
        }
    }

    public enum GameState
    {
        MainMenu,
        Play,
        Pause,
        Options,
        Exit,
        Win,
        Lose
    }
}