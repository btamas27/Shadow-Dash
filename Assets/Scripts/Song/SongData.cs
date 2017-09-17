using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class SongDataList
{
    public SongData[] data;
}

[Serializable]
public class SongData
{
    public float pitch;
    public float db;
    public float time;

    public SongData(float pith, float db, float time)
    {
        this.pitch = pith;
        this.db = db;
        this.time = time;
    }

    public override string ToString()
    {
        return string.Format("[SongData: pitch={0}, db={1}, time={2}]", pitch, db, time);
    }
    
}