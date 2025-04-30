using System;
//using System.Security.Cryptography;

namespace ExternalModel {
    [System.Serializable]
    public class Association {
        //private static readonly MD5 md5 = MD5.Create();
        public string front;
        public string back;

        /*
        public string Key() {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(front + back);
            byte[] hash = md5.ComputeHash(bytes);

            return BitConverter.ToString(hash);
        }
        */
    }
}