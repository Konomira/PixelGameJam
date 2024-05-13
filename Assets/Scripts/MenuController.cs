using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public List<MenuButton> menuButtons;
    public string nextScene;
    private MenuButton selectedButton;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip open;
    public AudioClip close;
    public AudioClip[] notes;

    public Action<MenuButton> OnHoverEnter;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        OnHoverEnter += HoverEnter;
    }

    private void Start()
    {
        selectedButton = menuButtons[0];
        selectedButton.Highlight();
    }

    private void HoverEnter(MenuButton button)
    {
        var index = menuButtons.IndexOf(button);

        foreach(var b in menuButtons)
        {
            b.Unhighlight();
        }

        menuButtons[index].Highlight();
        selectedButton = menuButtons[index];

        if (notes.Length > index + 1)
        {
            audioSource.PlayOneShot(notes[index]);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            var i = menuButtons.IndexOf(selectedButton) + 1;
            
            if (i >= menuButtons.Count)
                i = 0;

            selectedButton.Unhighlight();
            selectedButton = menuButtons[i];
            selectedButton.Highlight();
            
            if(notes.Length > i + 1)
                audioSource.PlayOneShot(notes[i]);
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            var i = menuButtons.IndexOf(selectedButton) - 1;
            
            if(i < 0)
                i = menuButtons.Count - 1;

            selectedButton.Unhighlight();
            selectedButton = menuButtons[i];
            selectedButton.Highlight();

            if (notes.Length > i + 1)
                audioSource.PlayOneShot(notes[i]);
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            selectedButton.button.onClick?.Invoke();    
        }
    }

    public void Close()
    {
        animator.Play("Close");
    }

    public void PlayOpenSound()
    {
        audioSource.PlayOneShot(open);
    }

    public void PlayCloseSound()
    {
        audioSource.PlayOneShot(close);
    }

    public void OnAnimationFinished()
    {
        SceneManager.LoadScene(nextScene);
        
    }
}
