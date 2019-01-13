using System;
using System.Collections.Generic;
using System.Text;
using TestPanda.Api.ErrorHandling;

namespace TestPanda.Core
{
    /// <summary>
    /// This allows a a result to be returned with a status
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelState<T> : IModelState
    {
        /// <summary>
        /// This contains the return result, or if there are errors it will retunr default(T)
        /// </summary>
        T Result { get; set; }
    }
}
