using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Plugin.Media;
using Xamarin.Forms;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace share.PersonalPage
{
    [DataContract]
    internal class Data
    {
        [DataMember]
        internal string Name = "a", NickName = "b", PhoneNumber = "c";
    }
    class PersonalData
    {
        public static PersonalData main = new PersonalData();
        public Data data = new Data();
        private void ReadToData(string s)
        {
            Debug.WriteLine("ReadToData1");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Data));
            Debug.WriteLine("ReadToData2");
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
            Debug.WriteLine("ReadToData3");
            stream.Position = 0;
            data = (Data)ser.ReadObject(stream);
            Debug.WriteLine("ReadToData4");
        }
        private string WriteFromData()
        {
            Data data = new Data();
            Debug.WriteLine("WriteFromData1");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Data));
            Debug.WriteLine("WriteFromData2");
            MemoryStream stream = new MemoryStream();
            Debug.WriteLine("WriteFromData3");
            ser.WriteObject(stream, data);
            Debug.WriteLine("WriteFromData4");
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            Debug.WriteLine("WriteFromData5");
            return reader.ReadToEnd();
        }
        public PersonalData()
        {
            LoadAsync();
        }
        public async void SaveAsync()
        {
            // https://msdn.microsoft.com/zh-tw/library/bb412179(v=vs.110).aspx
            //IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await (await FileSystem.Current.LocalStorage.CreateFolderAsync("SharingCar", CreationCollisionOption.OpenIfExists)).CreateFolderAsync("PersonalSettings", CreationCollisionOption.OpenIfExists);
            IFile sourceFile = await sourceFolder.CreateFileAsync("Settings.ini", CreationCollisionOption.OpenIfExists);
            await sourceFile.WriteAllTextAsync(WriteFromData());
            
        }
        public async void LoadAsync()
        {
            //IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder sourceFolder = await (await FileSystem.Current.LocalStorage.CreateFolderAsync("SharingCar", CreationCollisionOption.OpenIfExists)).CreateFolderAsync("PersonalSettings", CreationCollisionOption.OpenIfExists);
            IFile sourceFile = await sourceFolder.CreateFileAsync("Settings.ini", CreationCollisionOption.OpenIfExists);
            
            //await sourceFile.WriteAllTextAsync("這是我自己寫入檔案的內容");
            var fooContent = await sourceFile.ReadAllTextAsync();
            if(fooContent.Length!=0)
            {
                ReadToData(fooContent);
            }
        }
    }
}
