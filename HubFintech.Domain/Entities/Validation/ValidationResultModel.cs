using System;
using System.Collections.Generic;
using System.Text;

namespace DFK.Domain.Entities.Validation
{
    public class ValidationResultModel
    {
        public ValidationResultModel()
        {
            Erros = new List<string>();
        }

        public IList<string> Erros { get; }
        public bool IsValid { get => Erros.Count <= 0; }
        public string Message { get; set; }

        public void Add(string error) => Erros.Add(error);
    }
}
