using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{

    public static GameControl control;

    public float points;
    public float time;

    // Use this for initialization
    void Awake()
    {
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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerScore.dat");

        PlayerScore data = new PlayerScore();
        data.points = ScoreManager.score;
        data.time = Timer.timeLeft;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerScore.dat", FileMode.Open);
            PlayerScore data = ((PlayerScore)bf.Deserialize(file));
            file.Close();

            points = data.points;
            time = data.time;
        }
    }
}

[Serializable]
class PlayerScore
{
    public float points;
    public float time;
}
