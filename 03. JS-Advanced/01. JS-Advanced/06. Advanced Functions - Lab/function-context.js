let universe = 'DCU';

function heroFight() {
    let heroName = 'Superman';

    console.log(`${heroName} is from ${universe}`);
}

heroFight();

// Examle 3 Chnage funcions
function fly(info, second) {
    console.log(`${this.name} is flying!!! ${info}`);
}

let contextObject = {
    name: 'Wonder Woman'
};

fly('With cape'); // global context
fly.call(contextObject, 'With rope');
fly.call({name: 'Pesho'});
fly.apply({name: 'gosho'}, ['With fork']);

// Using bind
let wonderWomanFly = fly.bind(contextObject);

wonderWomanFly('With plane');
wonderWomanFly('se taq');