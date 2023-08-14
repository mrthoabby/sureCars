using MongoDB.Bson;

namespace Infrastructure.Helpers
{

    /// <summary>
    /// No es el idea hacer este tipo de cosas pero la base de datos no se presta para auto incrementables numericos ademas de está practica está desrecomendad.
    /// Adicional hubiera sido practico utilizar un Patros Mediador para cumplir al 100% con resposabilidad unica ya que no debería ser responsabilidad
    /// del respositorio de coverage hacer ajustes relacionados a indicex de la base de datos
    /// </summary>
    public class CounterAutoIncremental
    {
        public ObjectId Id { get; set; }
        public string Identifier { get; set; }
        public int currentCounterValue { get; set; }
    }
}
