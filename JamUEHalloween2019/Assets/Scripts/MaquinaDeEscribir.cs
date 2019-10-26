using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text;
using System.IO;

public class MaquinaDeEscribir : MonoBehaviour
{
    [SerializeField] Text playerText;
    [SerializeField] Text previewText;
    [SerializeField] Image paperImage;
    [SerializeField] UnityEvent onWritingEnd;
    [SerializeField] Transform chairTransform;

    string filename = "./Assets/Text/texto.txt";
    List<string> words = new List<string>();
    List<string> playerInput = new List<string>();
    AudioSource audioSource;
    public bool writing = false;
    public bool annoyed = false;
    bool shiftPressed = false;

    KeyCode lastKeyCode;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (writing && !annoyed)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    ProcessPlayerInput(vKey.ToString());
                    lastKeyCode = vKey;
                    audioSource.PlayOneShot(audioSource.clip);
                }
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                shiftPressed = true;
            else
                shiftPressed = false;

            if (Input.GetKeyDown(KeyCode.Space)) Compare();
        }
        if (Input.GetKeyDown(KeyCode.Return)) onWritingEnd.Invoke();
    }

    void ProcessPlayerInput(string input)
    {
        if(input.Length == 1) //Sabemos que es letra segura
        {
            if(!shiftPressed)
                input = input.ToLower();
            if (lastKeyCode.ToString() == "Quote")
                ProcessQuote(input);
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

        else
        {
            ProcessNumbers(input);
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

    void ProcessNumbers(string input)
    {
        switch(input)
        {
            case "Alpha0":
                playerInput.Add("0");
                WritePlayerText("0");
                break;
            case "Alpha1":
                playerInput.Add("1");
                WritePlayerText("1");
                break;
            case "Alpha2":
                playerInput.Add("2");
                WritePlayerText("2");
                break;
            case "Alpha3":
                playerInput.Add("3");
                WritePlayerText("3");
                break;
            case "Alpha4":
                playerInput.Add("4");
                WritePlayerText("4");
                break;
            case "Alpha5":
                playerInput.Add("5");
                WritePlayerText("5");
                break;
            case "Alpha6":
                playerInput.Add("6");
                WritePlayerText("6");
                break;
            case "Alpha7":
                playerInput.Add("7");
                WritePlayerText("7");
                break;
            case "Alpha8":
                playerInput.Add("8");
                WritePlayerText("8");
                break;
            case "Alpha9":
                playerInput.Add("9");
                WritePlayerText("9");
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

            if (words.Count == 0) GameOver.EndGame();

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

    public void startWriting(bool b)
    {
        writing = b;
        playerText.gameObject.SetActive(b);
        previewText.gameObject.SetActive(b);
        paperImage.gameObject.SetActive(b);
    }
}