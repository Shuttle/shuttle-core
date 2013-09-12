using System.Collections.Generic;

namespace Shuttle.Core.Data
{
    public interface IWhereExpressionContainer
    {
        void AddWhereExpression(IWhereExpression expression);
    	IEnumerable<IWhereExpression> WhereClauseExpressions { get; }
    }
}