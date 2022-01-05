namespace Gym.Repositories
{
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> equipments;
        public EquipmentRepository()
        {
            this.equipments = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)this.equipments;

        public void Add(IEquipment model)
        {
            this.equipments.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            var equipment = this.equipments.FirstOrDefault(x => x.GetType().Name == type);
            return equipment;
        }

        public bool Remove(IEquipment model)
        {
            return this.equipments.Remove(model);
        }
    }
}
