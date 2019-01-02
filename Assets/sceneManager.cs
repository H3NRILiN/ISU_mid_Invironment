using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{
    public GameObject PlayerCtrls;
    public GameObject Player;
    public GameObject _Fade;
    public Animator _FadeAnim;
    public Scene[] scenes;

    public static sceneManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _Fade.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(PlayerCtrls);
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene(int scene)
    {
        if(SceneManager.sceneCount!=0)
        SceneManager.LoadScene(scene);
    }

    public void Fading(int state)
    {
        if (state == 0)
            _FadeAnim.Play("FadeIn");
        if (state == 1)
            _FadeAnim.Play("FadeOut");
    }

}
