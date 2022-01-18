let student = {
    firstName: 'Maria',
    lastName: 'Lopez',
    age: 22,
    location: {
        coordinates: {
            lat: 42.698, lng: 23.322
        },
        locationName: 'Sofia'
    }
}

const {location: {coordinates}} = student

console.log(coordinates);

console.log(student);
console.log(student.location.coordinates.lat);



function print() {
    console.log(`${this.name} is printing a page.`);
}

function scan() {
    console.log(`${this.name} is scanning a document.`);
}

const printer = {
    name: 'ACME Printer',
    print
};

const scanner = {
    name: 'Initech Scanner',
    scan
}

const copier = {
    name: 'ConTron Copier',
    print,
    scan
}

printer.print();
copier.print();



