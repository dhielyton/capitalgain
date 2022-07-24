using CapitalGain.Application.Helper;
using CapitalGain.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalGain.Application.Service
{
    public class OperationService
    {
        public List<TaxDTO> Process(string operationsJson)
        {
            var opertions = operationsJson.Convert();
            foreach (var operation in opertions)
            {


            }

            return null;

        }
    }
}
