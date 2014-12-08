using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Models
{
    public interface IDbModel
    {
        bool IsFromDb { get; } // true iff Model was returned by a query
        bool DirtyBit { get; } // initially false, should be set if IsFromDb && state updated since query

        bool AddToDb();
        bool DeleteFromDb();
        bool UpdateInDb();
        // IMO searching/getting (queries) should be provided by external class being sort of a factory class for IDbModels
    }
}
