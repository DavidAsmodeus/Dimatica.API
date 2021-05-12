using CrossCutting.Settings;
using Dimatica.Application.Contract;
using Dimatica.Application.Model;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Dimatica.Application.Implementation
{
    /// <summary>
    /// Implementación de la interfaz de Duty de la capa aplicación
    /// -------------------------------------------------------------------------
    /// NOTA:
    /// -------------------------------------------------------------------------
    /// Para el propósito de este test el acceso al sistema de persistencia
    /// se hará directamente en esta capa, no existiendo capas de infraestructura
    /// ni tampoco de dominio, y usando como DTO directamente la entidad Duty
    /// -------------------------------------------------------------------------
    /// </summary>
    public class DutyApplicacion : IDutyApplicacion
    {
        private readonly IMongoCollection<Duty> dutiesDb;

        public DutyApplicacion(IDutyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            dutiesDb = database.GetCollection<Duty>(settings.DutiesCollectionName);
        }

        #region crud actions

        public List<Duty> GetDuties()
        {
            return dutiesDb.Find(_ => true).ToList();
        }

        public Duty GetDutyById(string id)
        {
            return dutiesDb.Find(d => d.Id == id).FirstOrDefault();
        }

        public Duty AddDuty(Duty duty)
        {
            dutiesDb.InsertOne(duty);
            return duty;
        }

        public Duty UpdateDuty(Duty duty)
        {
            dutiesDb.ReplaceOne(d => d.Id == duty.Id, duty);
            return duty;
        }

        public void DeleteDuty(string id)
        {
            dutiesDb.DeleteOne(d => d.Id == id);
        }

        #endregion
    }
}
