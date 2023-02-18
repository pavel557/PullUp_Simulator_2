using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;
using System.IO;
using System;

public class SaveManager : Singleton<SaveManager>
{
    private string Path = Application.persistentDataPath + "saveFile.sav";

    public void SaveGame()
    {
        byte[] bytes = MessagePackSerializer.Serialize(The.GameSession.Parameters);

        using var stream = File.Open(Path, FileMode.OpenOrCreate);
        using var writer = new BinaryWriter(stream);
        writer.Write(bytes.Length);
        writer.Write(bytes);
    }

    public void LoadGame()
    {
        try
        {
            if (!File.Exists(Path))
            {
                throw (new Exception("File is null"));
            }
            using var stream = File.OpenRead(Path);
            using var reader = new BinaryReader(stream);
            var dataLength = reader.ReadInt32();
            var dataBytes = reader.ReadBytes(dataLength);

            var parameters = MessagePackSerializer.Deserialize<GameSessionParameters>(dataBytes);
            The.GameSession.Init(parameters);
            Debug.Log("Save load");
        }
        catch
        {
            The.GameSession.Init();
            Debug.Log("Save not load");
        }
        
    }
}
