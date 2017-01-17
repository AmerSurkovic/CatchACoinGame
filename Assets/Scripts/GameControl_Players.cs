using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameControl_Players : MonoBehaviour {

    public static GameControl_Players control;

    public List<PlayerRecord> playerScores;

    public float points;
    public float time;
    public string name;

    public static GameObject fpc;

    public static int nmb;

    public static bool loadGame;

    // Use this for initialization
    void Awake()
    {
        playerScores = new List<PlayerRecord>();
        Load();
        nmb = 1;

        fpc = GameObject.Find("FPSController");

        if (loadGame == true)
        {
            LoadPosition();
        }

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //    points = ScoreManager.score;
        //    time = Timer.timeLeft;
    }

    public void Save()
    {
        PlayerRecord data = new PlayerRecord();
        data.points = ScoreManager.score;
        data.time = Timer.timeLeft;
        data.name = "testUsername " + nmb.ToString();
        nmb++;

        playerScores.Add(data);

        BinaryFormatter bf = new BinaryFormatter();
        string filepath = Application.persistentDataPath + "/highscores.dat";

        //serialize
        using (Stream stream = File.Open(filepath, FileMode.Create))
        {
            var bformatter = new BinaryFormatter();

            bformatter.Serialize(stream, playerScores);
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/highscores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            string filepath = Application.persistentDataPath + "/highscores.dat";
            
            //deserialize
            using (Stream stream = File.Open(filepath, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();

                playerScores = (List<PlayerRecord>)bformatter.Deserialize(stream);
            }
        }
    }

    public string Write()
    {
        string write = "";
        foreach(PlayerRecord x in playerScores)
        {
            write += x.points + " ";
        }
        return write;
    }

    public List<PlayerRecord> HighScore()
    {
        Load();
        return playerScores;
    }


    public void SavePosition()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + "/lastPlayerPosition.dat", FileMode.Create);
        PlayerPosition data = new PlayerPosition();
        Vector3 position = fpc.gameObject.transform.position;
        Quaternion rotation = fpc.gameObject.transform.rotation;

        data.points = ScoreManager.score;
        data.time = Timer.timeLeft;

        data.posX = position.x;
        data.posY = position.y;
        data.posZ = position.z;
        data.rotX = rotation.x;
        data.rotY = rotation.y;
        data.rotZ = rotation.z;
        data.rotW = rotation.w;

        bf.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadPosition()
    {
        if(File.Exists(Application.persistentDataPath + "/lastPlayerPosition.dat"))
        { 
            BinaryFormatter bf = new BinaryFormatter();
            FileStream filestream = File.Open(Application.persistentDataPath + "/lastPlayerPosition.dat", FileMode.Open);
            PlayerPosition data = (PlayerPosition)bf.Deserialize(filestream);
            filestream.Close();

            fpc.gameObject.transform.position = new Vector3(data.posX, data.posY, data.posZ);
            fpc.gameObject.transform.rotation = new Quaternion(data.rotX, data.rotY, data.rotZ, data.rotW);

            ScoreManager.score = (int) data.points;
            Timer.timeLeft = data.time;
            Time.timeScale = 1;
        }
    }

}

[System.Serializable]
public class PlayerRecord
{
    public string name;
    public float points;
    public float time;
}

[System.Serializable]
public class PlayerPosition
{
    public float posX;
    public float posY;
    public float posZ;
    public float rotX;
    public float rotY;
    public float rotZ;
    public float rotW;
    public float points;
    public float time;
}
