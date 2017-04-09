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
using System.Reflection;

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
        public class BindingData:BindableObject
        {
            public static readonly BindableProperty BindingNameProperty = BindableProperty.Create("BindingName", typeof(string), typeof(Edit_Page));
            public static readonly BindableProperty BindingNickNameProperty = BindableProperty.Create("BindingNickName", typeof(string), typeof(Edit_Page));
            public static readonly BindableProperty BindingPhoneNumberProperty = BindableProperty.Create("BindingPhoneNumber", typeof(string), typeof(Edit_Page));

            // The following attributes must be public
            public string BindingName
            {
                get { return (string)GetValue(BindingNameProperty); }
                set { SetValue(BindingNameProperty, value); }
            }
            public string BindingNickName
            {
                get { return (string)GetValue(BindingNickNameProperty); }
                set { SetValue(BindingNickNameProperty, value); }
            }
            public string BindingPhoneNumber
            {
                get { return (string)GetValue(BindingPhoneNumberProperty); }
                set { SetValue(BindingPhoneNumberProperty, value); }
            }


            private BindableProperty GetFieldTextProperty(object v)
            {
                var p = v.GetType().GetRuntimeField("TextProperty");
                var q = p.GetValue(null);
                return q as BindableProperty;
            }
            private void SetOneBinding(object v,string name)
            {
                var t = v.GetType();
                {
                    var m = t.GetRuntimeMethod("SetBinding", new Type[] { typeof(BindableProperty), typeof(BindingBase) });
                    m.Invoke(v, new object[] { GetFieldTextProperty(v), new Binding(name, BindingMode.TwoWay) });
                }
                {
                    var f = t.GetRuntimeProperty("BindingContext");
                    f.SetValue(v, this);
                }
            }
            public void SetBinding(object vName, object vNickName, object vPhoneNumber)
            {
                SetOneBinding(vName, "BindingName");
                SetOneBinding(vNickName, "BindingNickName");
                SetOneBinding(vPhoneNumber, "BindingPhoneNumber");
            }
            public void SaveAsync(ref PersonalData data)
            {
                data.data.Name = BindingName;
                data.data.NickName = BindingNickName;
                data.data.PhoneNumber = BindingPhoneNumber;
                data.SaveAsync();
            }
            public BindingData(PersonalData data)
            {
                BindingName = data.data.Name;
                BindingNickName = data.data.NickName;
                BindingPhoneNumber = data.data.PhoneNumber;
            }
        }
        public static PersonalData main = new PersonalData();
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
            Data data = new Data();
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
            //Debug.WriteLine("HI");
            //Debug.WriteLine(await sourceFile.ReadAllTextAsync());
            //Debug.WriteLine(FileSystem.Current.LocalStorage.Path);
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
