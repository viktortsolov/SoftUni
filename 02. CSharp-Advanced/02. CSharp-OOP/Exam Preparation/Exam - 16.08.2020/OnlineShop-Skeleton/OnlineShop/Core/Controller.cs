using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<Models.Products.Components.IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<Models.Products.Components.IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfContains(computerId);

            Models.Products.Components.Component component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            if (component == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer.Components.Any(x => x.Id == component.Id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            components.Add(component);
            computer.AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Computer computer = null;
            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            if (this.computers.Any(x => x.Id == computer.Id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfContains(computerId);

            Peripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            if (peripheral == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer.Peripherals.Any(x => x.Id == peripheral.Id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }
        public string BuyBest(decimal budget)
        {
            var sortedComputers = this.computers.OrderByDescending(x => x.OverallPerformance);

            IComputer computerToBuy = null;
            foreach (var computer in sortedComputers)
            {
                if (computer.Price <= budget)
                {
                    computerToBuy = computer;
                    break;
                }
            }

            if (computerToBuy == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computerToBuy);
            return computerToBuy.ToString();
        }
        public string BuyComputer(int id)
        {
            CheckIfContains(id);

            var computer = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computer);

            return computer.ToString();
        }
        public string GetComputerData(int id)
        {
            CheckIfContains(id);

            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }
        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfContains(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.RemoveComponent(componentType);

            var component = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }
        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfContains(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.RemovePeripheral(peripheralType);

            var peripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void CheckIfContains(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
