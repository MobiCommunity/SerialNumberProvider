namespace SerialNumberProvider.Core.Services.Abstract
{
    public interface IShaCalculator
    {
        string Compute(string value);
    }
}