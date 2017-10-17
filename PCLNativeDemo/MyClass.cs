using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using System.Collections.Generic;


namespace PCLNativeDemo
{
    public class MyClass
    {
        public MyClass()
        {
            Debug.WriteLine("Hello Class initlization");
            //readDataFromFile();
        }

        public static List<RootObject> readDataFromFile()
        {
            
            var assembly = typeof(MyClass).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("PCLNativeDemo.person.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            Debug.WriteLine("Hello Class initlization"+text);
            var rootobject = JsonConvert.DeserializeObject<List<RootObject>>(text);
            Debug.WriteLine("Hello Class initlization" + rootobject);

            return rootobject;
        }
    }
}
