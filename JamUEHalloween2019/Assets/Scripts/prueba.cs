using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
//Attach this script to a GameObject.
//Create a Text GameObject (Create>UI>Text) and attach it to the My Text field in the Inspector of your GameObject
//Press the space bar in Play Mode to see the Text change.

using UnityEngine.UI;

public class prueba : MonoBehaviour
{
    /*
    public Text m_MyText;
    public string escrito;
    public string[] texto;
    public int contador;

    void Start()
    {
        //Text sets your text to say this message
        Load("../Text/texto.txt");
    }

    void Update()
    {
        //Press the space key to change the Text message
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                actualizarEscrito(vKey);
            }
        }
    }

    void Load(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();
                    console.log(line);
                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        // In this example, I split it into arguments based on comma
                        // deliniators, then send that array to DoStuff()
                        string[] palabro = line.Split(' ');
                        if (palabro.Length > 0)
                            texto = palabro;
                    }
                } while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
        }
    }

    void escribirPagina(string palabro)
    {
        m_MyText.text = palabro;
        //tocarian las unity shenanigans idk
    }

    void actualizarEscrito(char letra)
    {
        if (m_MyText.text.length < escrito.length)
        {
            borrarEscrito();
        }
        else if (letra == ' ')
        {
            comparar();
        }
        else
        {
            //actualizar la pagina con las letras en negro
            escrito = escrito + letra;
        }
    }

    void comparar()
    {
        if (m_MyText.text == escrito)
        {

        }
        else
        {
            borrarEscrito();
        }
    }

    void borrarEscrito()
    {
        //unity shenanigans para borrar lo escrito hasta ahora
        escrito = "";
    }*/

}





