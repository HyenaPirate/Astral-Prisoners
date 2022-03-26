using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
	// Skrypt wlacza loading screen i laduje podana scene

	public GameObject loadingScreen;
	public Slider slider;
	public Text progressText;
	
	public void LoadLevel (int sceneIndex) // To tutaj jesli chcesz zaladowac scene, np LoadLevel(1); bo 1 to menu
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	
	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		loadingScreen.SetActive(true);
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			//Debug.Log(operation.progress);
			
			slider.value = progress;
			progressText.text = progress *100f + "%";
			
			yield return null;
		}
	}
}
