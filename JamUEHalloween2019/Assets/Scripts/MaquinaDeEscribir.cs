﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class MaquinaDeEscribir : MonoBehaviour
{
    [SerializeField] Text playerText;
    [SerializeField] Text previewText;

    string filename = "./Assets/Text/texto.txt";
    List<string> words = new List<string>();
    List<string> playerInput = new List<string>();
    bool writing = false;

    bool shiftPressed = false;

    KeyCode lastKeyCode;

    public AudioClip sonidoTecleo;

    void Start()
    {
        LoadText(filename);
        playerText.text = "";
        previewText.text = "";

        previewText.text = words[0];
    }

    void LoadText(string filename)
    {
        string line;
        string[] aux;

        StreamReader theReader = new StreamReader(filename, Encoding.Unicode);
        line = theReader.ReadLine();

        while (line != null)
        {
            aux = line.Split(' ');

            for (int i = 0; i < aux.Length; i++)
                words.Add(aux[i]);

            line = theReader.ReadLine();
        }
    }

    void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                ProcessPlayerInput(vKey.ToString());
                lastKeyCode = vKey;
                EfectoTecleo.Sonido("tecla");
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            shiftPressed = true;
        else
            shiftPressed = false;

        if (Input.GetKeyDown(KeyCode.Space)) Compare();
    }

    void ProcessPlayerInput(string input)
    {
        if(input.Length == 1) //Sabemos que es letra segura
        {
            if(!shiftPressed) input = input.ToLower();

            if (lastKeyCode.ToString() == "Quote") ProcessQuote(input);

            else
            {
                playerInput.Add(input);
                WritePlayerText(input);
            }
        }

        else if (input == "Comma")
        {
            playerInput.Add(",");
            WritePlayerText(",");
        }

        else if(input == "Period")
        {
            if(shiftPressed)
            {
                playerInput.Add(":");
                WritePlayerText(":");
            }

            else
            {
                playerInput.Add(".");
                WritePlayerText(".");
            }
        }

        else if (input == "BackQuote")
        {
            if (!shiftPressed)
            {
                playerInput.Add("ñ");
                WritePlayerText("ñ");
            }
            else
            {
                playerInput.Add("Ñ");
                WritePlayerText("Ñ");
            }
        }

        else if(input == "Backspace" && playerInput.Count > 0)
        {
            playerInput.RemoveAt(playerInput.Count - 1);

            string playerWord = "";

            foreach (string key in playerInput) playerWord += key;

            playerText.text = previewText.text.Substring(0, previewText.text.Length - words[0].Length) + playerWord;
        }
        
    }

    void ProcessQuote(string input)
    {
        switch (input)
        {
            case "A":
                playerInput.Add("Á");
                WritePlayerText("Á");
                break;

            case "E":
                playerInput.Add("É");
                WritePlayerText("É");
                break;

            case "I":
                playerInput.Add("Í");
                WritePlayerText("Í");
                break;

            case "O":
                playerInput.Add("Ó");
                WritePlayerText("Ó");
                break;

            case "U":
                playerInput.Add("Ú");
                WritePlayerText("Ú");
                break;

            case "a":
                playerInput.Add("á");
                WritePlayerText("á");
                break;

            case "e":
                playerInput.Add("é");
                WritePlayerText("é");
                break;

            case "i":
                playerInput.Add("í");
                WritePlayerText("í");
                break;

            case "o":
                playerInput.Add("ó");
                WritePlayerText("ó");
                break;

            case "u":
                playerInput.Add("ú");
                WritePlayerText("ú");
                break;
        }
    }

    void Compare()
    {
        string playerWord = "";

        foreach(string key in playerInput) playerWord += key;

        if(words[0] == playerWord)
        {
            playerText.text = previewText.text;

            playerText.text += " ";
            previewText.text += " ";
            
            DeletePlayerInput();
            words.RemoveAt(0);
            if (words[0] != null) previewText.text += words[0];
        }

        else
        {
            DeletePlayerText();
        }
    }

    void WritePlayerText(string input)
    {
        playerText.text += input;
    }

    void DeletePlayerInput()
    {
        playerInput = new List<string>();
    }

    void DeletePlayerText()
    {
        int offset = Mathf.Abs(playerText.text.Length - playerInput.Count);

        char[] aux = playerText.text.ToCharArray();
        string newPlayertext = "";

        for (int i = 0; i < offset; i++) newPlayertext += aux[i];

        playerText.text = newPlayertext;
        DeletePlayerInput();
    }
}