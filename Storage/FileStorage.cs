using Lab_WebAPI.Models;
using Newtonsoft.Json;

namespace Lab_WebAPI.Storage
{
    public class FileStorage : MemCache, IStorage<PersonalComputerData>
    {
        private Timer _timer;

        public string FileName { get; }
        public int FlushPeriod { get; }

        public FileStorage(string fileName, int flushPeriod)
        {
            FileName = fileName;
            FlushPeriod = flushPeriod;

            Load();

            _timer = new Timer((x) => Flush(), null, flushPeriod, flushPeriod);
        }

        private void Load()
        {
            if (File.Exists(FileName))
            {
                var allLines = File.ReadAllText(FileName);

                try
                {
                    var deserialized = JsonConvert.DeserializeObject<List<PersonalComputerData>>(allLines);

                    if (deserialized != null)
                    {
                        foreach (var PersonalComputerData in deserialized)
                        {
                            base[PersonalComputerData.Id] = PersonalComputerData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new FileLoadException($"Cannot load data from file {FileName}:\r\n{ex.Message}");
                }
            }
        }

        private void Flush()
        {
            var serializedContents = JsonConvert.SerializeObject(All);

            File.WriteAllText(FileName, serializedContents);
        }
    }
}
