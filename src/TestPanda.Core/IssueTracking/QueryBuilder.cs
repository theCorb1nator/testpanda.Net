using System.Collections;

namespace TestPanda.Core
{
    public class QueryBuilder
    {
        private IDictionary _Fields;
        public QueryBuilder()
        {

        }
        void AddField(string fieldName, string value)
        {
            _Fields.Add(fieldName, value);
        }
        public Query Build()
        {
            Query query = new Query();
            return query;
        }
    }
}