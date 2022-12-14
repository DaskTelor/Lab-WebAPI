using Newtonsoft.Json;

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
        public Guid Id { get; set; } = Guid.Empty;
        public ProcessorData? CPU { get; set; }
        public VideoCardData? GPU { get; set; }


        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(CPU.Name)) validationResult.Append($"CPU name cannot be empty");
            if (string.IsNullOrWhiteSpace(CPU.Producer)) validationResult.Append($"CPU producer cannot be empty");

            if (CPU.BaseFrequency < 0) validationResult.Append($"BaseFrequency {CPU.BaseFrequency} is out of range (0..)");
            if (CPU.AutoaccelerationFrequency < 0) validationResult.Append($"AutoaccelerationFrequency {CPU.AutoaccelerationFrequency} is out of range (0..)");
            if (CPU.NumberOfCores < 0) validationResult.Append($"NumberOfCores {CPU.NumberOfCores} is out of range (0..)");

            if (string.IsNullOrWhiteSpace(GPU.Name)) validationResult.Append($"GPU name cannot be empty");
            if (string.IsNullOrWhiteSpace(GPU.Producer)) validationResult.Append($"GPU producer cannot be empty");

            if (GPU.VRAM < 0) validationResult.Append($"VRAM {GPU.VRAM} is out of range (0..)");

            return validationResult;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
