using System;
using System.IO;
using System.Xml.Serialization;

namespace Server
{
    /// <summary>
    /// Для хранения конфигурации применим паттерн singleton. Т.е. класс не статичен, конструктор закрыт.
    /// Экземпляр класса можно получить через статик метод этого класса. А этот статик метод будет всегда возвращать один и тот же экземпляр.
    /// Таким образом экземпляр и сериализуется, и будет единственным при работе программы.
    /// </summary>

    [Serializable]
    public class Config
    {
        #region Properties

        public int ResolutionX { get; set; }                        // ширина изображения
        public int ResolutionY { get; set; }                        // высота изображения
        public int FrameRate { get; set; }                          // период генерации нового изображения, мс
        public int NetSpeed { get; set; }                           // период передачи данных по сети, мс
        public string Ip { get; set; }                              // IP-адрес хоста
        public int Port { get; set; }                               // номер порта для подключения

        #endregion

        #region Fields

        private static Config instance;

        #endregion

        #region Constructor

        private Config()
        {
            // значения по умолчанию, если будет ошибка загрузки данных
            ResolutionX = 320;
            ResolutionY = 240;
            FrameRate = 10;
            NetSpeed = 500;
            Ip = "127.0.0.1";
            Port = 8888;
        }

        #endregion

        #region Methods

        public static Config getInstance()
        {
            if (instance == null)
            {
                instance = new Config();
            }

            return instance;
        }

        public static void Save(string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(Config));

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, instance);
            }
        }

        public static void Load(string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(Config));

            using (var file = new FileStream(fileName, FileMode.Open))
            {
                instance = (Config)xmlFormatter.Deserialize(file);
            }
        }

        #endregion

    }
}
