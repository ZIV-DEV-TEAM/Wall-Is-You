using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string _fileName;
    [SerializeField] private bool _useEncryption;

    private GameData _gameData;
    private List<IDataPersistence> _dataPersistenceObjects;
    private FileDataHandler _dataHandler;


    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
        this._dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _useEncryption);
        this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }



    public void NewGame() 
    {
        this._gameData = new GameData();
    }

    public void LoadGame()
    {
        // load any saved data from a file using the data handler
        this._gameData = _dataHandler.Load();
        
        // if no data can be loaded, initialize to a new game
        if (this._gameData == null) 
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        // push the loaded data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    public void SaveGame()
    {
        this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        // pass the data to other scripts so they can update it
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects) 
        {
            dataPersistenceObj.SaveData(_gameData);
        }

        // save that data to a file using the data handler
        _dataHandler.Save(_gameData);
    }
    private void OnDestroy()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() 
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
