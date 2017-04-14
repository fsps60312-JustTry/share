using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using PCLStorage;
using Plugin.Media;
using System.Diagnostics;
using Newtonsoft.Json;

namespace share
{
    class DataStorer<T>
    {
        public static T Parse(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
        internal T data;
        private string saveFolderName,saveFileName;
        public DataStorer(T _data,string _saveFolderName,string _saveFileName)
        {
            data = _data;
            saveFolderName = _saveFolderName;
            saveFileName = _saveFileName;
        }
        public override string ToString()
        {
            return WriteFromData();
        }
        private void ReadToData(string s)
        {
            data = JsonConvert.DeserializeObject<T>(s);
        }
        private string WriteFromData()
        {
            return JsonConvert.SerializeObject(data);
        }
        public async Task SaveAsync()
        {
            // https://msdn.microsoft.com/zh-tw/library/bb412179(v=vs.110).aspx
            //IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await (await FileSystem.Current.LocalStorage.CreateFolderAsync("SharingCar", CreationCollisionOption.OpenIfExists)).CreateFolderAsync(saveFolderName, CreationCollisionOption.OpenIfExists);
            IFile sourceFile = await sourceFolder.CreateFileAsync(saveFileName, CreationCollisionOption.OpenIfExists);
            await sourceFile.WriteAllTextAsync(WriteFromData());
            //Debug.WriteLine("HI");
            //Debug.WriteLine(await sourceFile.ReadAllTextAsync());
            //Debug.WriteLine(FileSystem.Current.LocalStorage.Path);
        }
        public async Task LoadAsync()
        {
            //IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await (await FileSystem.Current.LocalStorage.CreateFolderAsync("SharingCar", CreationCollisionOption.OpenIfExists)).CreateFolderAsync(saveFolderName, CreationCollisionOption.OpenIfExists);
            IFile sourceFile = await sourceFolder.CreateFileAsync(saveFileName, CreationCollisionOption.OpenIfExists);
            //await sourceFile.WriteAllTextAsync("這是我自己寫入檔案的內容");
            var fooContent = await sourceFile.ReadAllTextAsync();
            if (fooContent.Length != 0)
            {
                ReadToData(fooContent);
            }
        }
    }
}
