﻿using System;

namespace MilitaryFaculty.KnowledgeTest.Entities.Exceptions
{
    public class RepositoryException : Exception
    {
        protected RepositoryException()
        {

        }

        public RepositoryException(string message)
            : base(message)
        {

        }

        public RepositoryException(Exception exception)
            : base("Inner exception.", exception)
        {

        }
    }
}
