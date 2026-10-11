using System.Data;
using Dapper;
using Google.Cloud.Spanner.Data;
using Google.Cloud.Spanner.V1;

namespace SpannerPlay.Data;


public class SpannerNumericTypeHandler : SqlMapper.TypeHandler<decimal>
{
    public override void SetValue(IDbDataParameter parameter, decimal value)
    {
        if (parameter is SpannerParameter spannerParameter)
        {
            spannerParameter.SpannerDbType = SpannerDbType.Numeric;
            spannerParameter.Value = SpannerNumeric.FromDecimal(value, LossOfPrecisionHandling.Truncate);
        }
        else
        {
            parameter.Value = value;
        }
    }

    public override decimal Parse(object value)
    {
        return value switch
        {
            decimal d => d,
            SpannerNumeric numeric => numeric.ToDecimal(LossOfPrecisionHandling.Truncate),
            string s => decimal.Parse(s),
            _ => Convert.ToDecimal(value)
        };
    }
}

