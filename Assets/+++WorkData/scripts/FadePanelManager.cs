using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadePanelManager : MonoBehaviour
{
  public DOTweenAnimation doTweenFadePanel;
  
  public void SimpleFadeAndChangeScene(string sceneName)
  {
    StartCoroutine(StartSimpleFadeAndChangeScene(sceneName));
  }
    
  IEnumerator StartSimpleFadeAndChangeScene(string sceneName)
  {
    doTweenFadePanel.DOPlayForward();
    yield return new WaitForSeconds(1);
    SceneManagers.LoadScene(sceneName);
  }

  public void SimpleFadeOut()
  {
    doTweenFadePanel.DOPlayBackwards();
  }
}
