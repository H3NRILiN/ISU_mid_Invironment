using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public int ChangetoScene;
    public int ChangeDelay;
    public Transform SpawnPoint;
    WaitForSeconds ChangeWait;
    private void Awake()
    { 

    }
    private void Start()
    {
        sceneManager.Instance.Fading(0);
        ChangeWait = new WaitForSeconds(ChangeDelay);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneManager.Instance.Fading(1);
            StartCoroutine(ChangingScene());
            
        }
    }
    IEnumerator ChangingScene()
    {
        yield return ChangeWait;
        sceneManager.Instance.Player.transform.position = SpawnPoint.position;
        yield return null;
        sceneManager.Instance.ChangeScene(ChangetoScene);
    }
}
