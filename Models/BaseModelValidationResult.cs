using System.Text;

namespace Lab_WebAPI.Models
{
    public class BaseModelValidationResult
    {
        private StringBuilder _errorBuilder = new StringBuilder();

        public bool IsValid { get; private set; } = true;
        public string Errors => _errorBuilder.ToString().Trim(); 

        public void Append(string error)
        {
            IsValid = false;
            _errorBuilder.AppendLine(error);
        }
    }
}
