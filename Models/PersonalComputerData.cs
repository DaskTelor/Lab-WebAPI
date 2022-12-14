
namespace Lab_WebAPI.Models
{
    public class ProcessorData
    {
        public string? Producer { get; set; }//производитель
        public string? Name { get; set; }//наименование
        public int BaseFrequency { get; set; }//базовая частота MHz
        public int AutoaccelerationFrequency { get; set; }//частота авторазгона MHz
        public int NumberOfCores { get; set; }//количество ядер
    }
    public class VideoCardData
    {
        public string? Producer { get; set; }//производитель
        public string? Name { get; set; }//наименование
        public int VRAM { get; set; }//видеопамять MB
    }
    public class PersonalComputerData
    {
        public ProcessorData? CPU { get; set; }
        public VideoCardData? GPU { get; set; }
    }
}
