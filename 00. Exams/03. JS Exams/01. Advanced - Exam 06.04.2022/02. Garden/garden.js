class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        if (spaceRequired > this.spaceAvailable) {
            throw new Error('Not enough space in the garden.')
        }

        let plant = {
            plantName,
            spaceRequired,
            'ripe': false,
            'quantity': 0
        }

        this.spaceAvailable -= spaceRequired;
        this.plants.push(plant);

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(x => x.plantName == plantName);

        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe == true) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        plant.ripe = true;
        plant.quantity += quantity;

        return quantity == 1
            ? `${quantity} ${plantName} has successfully ripened.`
            : `${quantity} ${plantName}s have successfully ripened.`;
    }

    harvestPlant(plantName) {
        let plant = this.plants.find(x => x.plantName == plantName);
        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (plant.ripe == false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        var plantForStorage = {
            'plantName': plant.plantName,
            'quantity': plant.quantity
        }

        this.plants = this.plants.filter(x => x.plantName != plantForStorage.plantName);
        this.spaceAvailable += plant.spaceRequired;
        this.storage.push(plantForStorage);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let result = [];

        result.push(`The garden has ${this.spaceAvailable} free space left.`);

        let plantsNamesInGarden = [];
        for (const plant of this.plants.sort((a, b) => a.plantName - b.plantName)) {
            plantsNamesInGarden.push(plant.plantName);
        }

        result.push(`Plants in the garden: ${plantsNamesInGarden.join(', ')}`);

        if (this.storage.length == 0) {
            result.push(`Plants in storage: The storage is empty`);
        }
        else {
            let plantsNamesInStorage = [];
            for (const plant of this.storage) {
                plantsNamesInStorage.push(`${plant.plantName} (${plant.quantity})`);
            }

            result.push(`Plants in storage: ${plantsNamesInStorage.join(', ')}`);
        }

        return result.join('\n');
    }
}