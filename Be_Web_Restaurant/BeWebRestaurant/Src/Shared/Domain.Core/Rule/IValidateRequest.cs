namespace Domain.Core.Rule
{
    public interface IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule();
    }
}