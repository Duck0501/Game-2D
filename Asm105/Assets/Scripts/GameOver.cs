using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private VisualElement homeElement;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        homeElement = root.Q<VisualElement>("home");
        homeElement.style.display = DisplayStyle.Flex;
        Button Play = root.Q<Button>("replay");
        Play.RegisterCallback<ClickEvent>(replay);
        Button Exit = root.Q<Button>("exit");
        Exit.RegisterCallback<ClickEvent>(exit);
    }

    private void replay(ClickEvent cke)
    {
        SceneManager.LoadScene("Level 1");
    }
    private void exit(ClickEvent cke)
    {
        SceneManager.LoadScene("Home");
    }
    void Update()
    {
        
    }
}
