using sureApp.domain.Interfaces;

namespace sureApp.domain.ValueObjects
{
    public record DateRange(DateTime From, DateTime To) : IValidator
    {
        public bool IsValid() => From < To;
    }
}
