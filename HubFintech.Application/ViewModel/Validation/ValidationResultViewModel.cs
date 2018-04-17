using System.Collections.Generic;

namespace HubFintech.Application.ViewModel.Validation
{
    public class ValidationResultViewModel
    {
        public IList<string> Erros { get; }
        public bool IsValid { get => Erros.Count > 0; }
        public string Message { get; set; }

        public void Add(string error) => Erros.Add(error);
    }
}