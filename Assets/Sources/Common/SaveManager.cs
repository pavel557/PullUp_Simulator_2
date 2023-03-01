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
        try
        {
            byte[] bytesParameters = MessagePackSerializer.Serialize(The.GameSession.Parameters);
            byte[] bytesShop = MessagePackSerializer.Serialize(The.ConfigManager.Shop);

            using var stream = File.Open(Path, FileMode.OpenOrCreate);
            using var writer = new BinaryWriter(stream);
            writer.Write(bytesParameters.Length);
            writer.Write(bytesParameters);
            writer.Write(bytesShop.Length);
            writer.Write(bytesShop);
            Debug.Log("File save");
        }
        catch
        {
            Debug.Log("File not save");
        }
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
            Debug.Log("file read");
            var parameters = MessagePackSerializer.Deserialize<GameSessionParameters>(dataBytes);
            The.GameSession.Init(parameters);
            Debug.Log("parametrs read");
            dataLength = reader.ReadInt32();
            dataBytes = reader.ReadBytes(dataLength);
            var shop = MessagePackSerializer.Deserialize<Shop>(dataBytes);
            The.ConfigManager.Init(shop);
            Debug.Log("Save load");
        }
        catch
        {
            The.GameSession.Init();
            The.ConfigManager.Init(new Shop());
            Debug.Log("Save not load");
        }
    }
}
