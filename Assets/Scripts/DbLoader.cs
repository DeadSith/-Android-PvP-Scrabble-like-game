using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DbLoader : MonoBehaviour
{
    public GameObject MainMenuCanvas;

    private void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        if (Application.platform == RuntimePlatform.Android)
        {
            var filepath = Path.Combine(Application.persistentDataPath, "words.db");
            if (!File.Exists(filepath))
            {
                MainMenuCanvas.GetComponent<Canvas>().enabled = false;
                gameObject.GetComponent<Canvas>().enabled = true;
                Extract();
            }
        }
    }

    private void Extract()
    {
        var loadZip = new WWW(Path.Combine(Application.streamingAssetsPath, "words.zip"));
        try
        {
            while (!loadZip.isDone)
            {
            }
            var zipPath = Path.Combine(Application.persistentDataPath, "words.zip");
            File.WriteAllBytes(zipPath, loadZip.bytes);
            using (var archive = new ZipInputStream(File.OpenRead(zipPath)))
            {
                var entry = archive.GetNextEntry();
                using (var sw = File.Create(Path.Combine(Application.persistentDataPath, entry.Name)))
                {
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = archive.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            sw.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            File.Delete(zipPath);
            MainMenuCanvas.GetComponent<Canvas>().enabled = true;
            gameObject.SetActive(false);
        }
        catch (Exception ex)
        {
            gameObject.GetComponentInChildren<Text>().text = ex.ToString();
            //Application.Quit();
        }
    }
}