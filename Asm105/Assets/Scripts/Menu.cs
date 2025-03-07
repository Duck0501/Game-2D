using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     private VisualElement homeElement;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        homeElement = root.Q<VisualElement>("home");
        homeElement.style.display = DisplayStyle.Flex;
        Button Play = root.Q<Button>("play");
        Play.RegisterCallback<ClickEvent>(playgame);
    }
    private void playgame(ClickEvent cke)
    {
        SceneManager.LoadScene("Level 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
