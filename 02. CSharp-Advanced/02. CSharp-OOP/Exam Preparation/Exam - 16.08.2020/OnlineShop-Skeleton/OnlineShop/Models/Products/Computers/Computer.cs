using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this.peripherals;

        public override double OverallPerformance
            => this.components.Count == 0 ? base.OverallPerformance : base.OverallPerformance + this.components.Average(x => x.OverallPerformance);

        public override decimal Price
            => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType() == component.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (components.Count == 0)
            {
                sb.AppendLine($" Peripherals ({0}); Average Overall Performance ({0:f2}):");
            }
            else
            {
                sb.AppendLine($" Components ({this.components.Count}):");
                foreach (var component in this.components)
                {
                    sb.AppendLine($"  {component.ToString()}");
                }
            }

            if (peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({0:f2}):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance):f2}):");
                foreach (var peripheral in this.peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
