using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SongDataCollector : MonoBehaviour
{
    public static SongDataCollector Instance{ get; set; }

    string path = "Assets/Resources/SoundData/data.txt";

    public SongDataList songDataList = new SongDataList();
    public List<SongData> songDatas = new List<SongData>();

    void Awake()
    {
        Instance = this;
        Load();
    }

    public void Add(SongData data)
    {
        songDatas.Add(data);
//        songDataList.data = songDatas.ToArray();
//        Save(data);
    }

    public void Save(SongData data)
    {
        string json = JsonUtility.ToJson(songDataList);
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(path);
        songDataList = JsonUtility.FromJson<SongDataList>(json);
    }
}