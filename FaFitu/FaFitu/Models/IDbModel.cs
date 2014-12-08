using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Models
{
    interface IDbModel
    {
        bool IsFromDb { get; } // true iff Model was returned by a query
        bool DirtyBit { get; } // true iff IsFromDb && state updated since query

        bool AddToDb();
        bool DeleteFromDb();
        bool UpdateInDb();
        // IMO searching/getting (queries) should be provided by external class being sort of a factory class for IDbModels
    }
}
