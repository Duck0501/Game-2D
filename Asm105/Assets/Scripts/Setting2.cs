using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Setting2 : MonoBehaviour
{
    private VisualElement homeElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void exit(ClickEvent cke)
    {
        SceneManager.LoadScene("Home");
    }
    private void Continue(ClickEvent cke)
    {
        SceneManager.LoadScene("Level 3");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            homeElement = root.Q<VisualElement>("home");
            homeElement.style.display = DisplayStyle.Flex;
            Button Exit = root.Q<Button>("exit");
            Exit.RegisterCallback<ClickEvent>(exit);
            Button ccontinue = root.Q<Button>("continue");
            ccontinue.RegisterCallback<ClickEvent>(Continue);
        }
    }
}
