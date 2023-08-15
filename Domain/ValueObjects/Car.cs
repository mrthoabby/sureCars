using sureApp.domain.Interfaces;

namespace sureApp.domain.ValueObjects
{
    public record Car(string Plate, string Model, bool IsItInspected)
    {
    }
}
