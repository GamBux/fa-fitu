using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public class RepositoryExceptions
    {
        [Serializable]
        public class UsersRepositoryException : Exception
        {
            public UsersRepositoryException(string message)
                : base(message)
            { }

            protected UsersRepositoryException(SerializationInfo info, StreamingContext ctxt)
                : base(info, ctxt)
            { }
        }

        [Serializable]
        public class FoodRepositoryException : Exception
        {
            public FoodRepositoryException(string message)
                : base(message)
            { }

            protected FoodRepositoryException(SerializationInfo info, StreamingContext ctxt)
                : base(info, ctxt)
            { }
        }
    }
}