using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UTN_TP.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public static event Action<GameState> OnGameStateChanged;

        readonly List<GameState> _stateHistory = new();

        public GameState previousState;
        public GameState currentState;


        void Awake() => Instance = Instance ? Instance : this;

        void Start() => UpdateGameState(GameState.MainMenu);


        public void UpdateGameState(GameState newState)
        {
            _stateHistory.Add(newState); 
            if(_stateHistory.Count > 2) _stateHistory.RemoveAt(0);
            previousState = _stateHistory[0];
            currentState = newState;
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
                case GameState.Quit:
                    Quit();
                    break;
                case GameState.Win:
                    break;
                case GameState.Die:
                    Lose();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        
            OnGameStateChanged?.Invoke(newState);

        }
        void Play()
        {
            if (previousState != GameState.Pause)
            {
                Loader.Add(Loader.Scenes.Controller);
                Loader.Add(Loader.Scenes.Level1);
            }
            Time.timeScale = 1;
        }


        static void Pause() => Time.timeScale = 0;
    

        static void Lose() => Loader.Reset();
        public void Back()
        {
            if (currentState == GameState.Pause)
            {
                Loader.Reset();
                UpdateGameState(GameState.MainMenu);
                return;
            }
            UpdateGameState(previousState);
        }

        static void Quit() => Application.Quit();

        public void UnloadAsync(string s) => StartCoroutine(UnloadAsyncRoutine(s));
        
        IEnumerator UnloadAsyncRoutine(string s)
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
        Quit,
        Win,
        Die
    }
}