using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private VisualElement homeElement;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        homeElement = root.Q<VisualElement>("homeW");
        homeElement.style.display = DisplayStyle.Flex;
        Button Replay = root.Q<Button>("Replay");
        Replay.RegisterCallback<ClickEvent>(replay);
        Button Exit = root.Q<Button>("Exit");
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
