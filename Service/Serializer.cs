using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace Service
{
    public class Serializer
    {

        public string dir = @"D:\JSONTest.txt";

        public int Save(Task obj)
        {
            try
            {

                string sex = JsonConvert.SerializeObject(obj);
                JsonSerializer ser = new JsonSerializer();
                //File.WriteAllText()
                using (StreamWriter file = File.AppendText(dir))
                {
                    ser.Serialize(file, obj);
                }
                    //var dex = JsonConvert.DeserializeObject<Exception>(sex);
                    return 1; }
            catch (Exception ex)
            {
                JsonSerializer ser = new JsonSerializer();
                using (StreamWriter file = File.CreateText(dir))
                {
                    ser.Serialize(file, obj);
                } 
                return ex.HResult;
            }
        }

        public void SerializeException()
        {
            Exception exception;
            try
            {
                throw new Exception();
            }
            catch (Exception ex)    
            {
                exception = ex;
            }
            string sex = JsonConvert.SerializeObject(exception);
            var dex = JsonConvert.DeserializeObject<Exception>(sex);

            //string sex = JsonConvert.SerializeObject(exception);
            //var dex = JsonConvert.DeserializeObject<Exception>(sex);

            //Assert.AreEqual(dex.ToString(), exception.ToString());
        }
    }
}
