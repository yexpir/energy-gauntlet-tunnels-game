using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UTN_TP.GameManagement
{
    public static class Loader
    {
        public enum Scenes
        {
            Manager,
            Controller,
            Level1
        }

        public static void Load(params Scenes[] scenes)
        {
            foreach (var scene in scenes) SceneManager.LoadScene((int)scene);
        }
        public static void Add(params Scenes[] scenes)
        {
            foreach (var scene in scenes) SceneManager.LoadScene((int)scene, LoadSceneMode.Additive);
        }
        public static void Reset()
        {
            var scenes = Enum.GetValues(typeof(Scenes));
            foreach (var scene in scenes)
            {
                var s = scene.ToString();
                if (s != Scenes.Manager.ToString())
                    GameManager.Instance.UnloadAsync(s);
            }
        }
        public static AsyncOperation UnloadAsync(string s) => SceneManager.UnloadSceneAsync(s);
        public static bool IsLoaded(string scene)
        {
            return SceneManager.GetSceneByName(scene).isLoaded;
        }

        public static bool AnyContains(string key)
        {
            var scenes = Enum.GetValues(typeof(Scenes));
            return (from object scene in scenes select scene.ToString()).Any(s => IsLoaded(s) && s.Contains(key));
        }

        static void Print(object msg) => Debug.Log(msg);
    }
}
