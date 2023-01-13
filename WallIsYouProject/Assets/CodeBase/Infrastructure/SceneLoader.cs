using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
          _coroutineRunner = coroutineRunner;
        public void Load(int index, Action onLoaded = null) =>
             _coroutineRunner.StartCoroutine(LoadScene(index, onLoaded));

        public IEnumerator LoadScene(int index, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(index);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}