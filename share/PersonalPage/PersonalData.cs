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

namespace share.PersonalPage
{
    class PersonalData
    {
        public static PersonalData main = new PersonalData();
        internal class Data
        {
            internal string Name="a", NickName="b", PhoneNumber="c";
        }
        public Data data = new Data();
        private void ReadToData(string s)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Data));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
            stream.Position = 0;
            data = (Data)ser.ReadObject(stream);
        }
        private string WriteFromData()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Data));
            MemoryStream stream = new MemoryStream();
            ser.WriteObject(stream, data);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
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
