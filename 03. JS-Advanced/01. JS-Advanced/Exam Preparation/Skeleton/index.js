function solve() {
    let buttonElement = document.querySelector('.admin-view .action button');
    let modules = {};

    buttonElement.addEventListener('click', (e) => {
        e.preventDefault();

        let lectureNameElement = document.querySelector('input[name="lecture-name"]');
        let lectureDateElement = document.querySelector('input[name="lecture-date"]');
        let lectureModuleElement = document.querySelector('select[name="lecture-module"]');

        if (!lectureNameElement.value || !lectureDateElement.value || lectureModuleElement.value == 'Select module') {
            return;
        }

        if (!modules[lectureModuleElement.value]) {
            modules[lectureModuleElement.value] = [];
        }

        let currentLecture = {
            name: lectureElement.value,
            data: formatDate(lectureDateElement.value)
        };
        modules[lectureModuleElement.value].push(currentLecture);

        createTrainings(modules);
    });

    function createTrainings(modules) {

        for (const module in modules) {
            let moduleElement = createModule(module);
            let lectureList = document.createElement('ul');

            let lectures = modules[module];

            lectures.sort((a, b) => a.date.localeCompare(b.date));

            lectureList.appendChild(lectureElement);
        }
        
        let lectureElement = createLecture(lectureNameElement.value, lectureDateElement.value);

        let modulesElement = document.querySelector('.modules');
        modulesElement.appendChild(moduleElement);
    }

    function createModule(name, lectureElement) {
        let divElement = document.createElement('div');
        divElement.classList.add('module');

        let headingElement = document.createElement('h3');
        headingElement.textContent = `${name.toUpperCase()}-MODULE`;

        divElement.appendChild(headingElement);

        return divElement;
    }

    function createLecture(name, date) {
        let liElement = document.createElement('li');
        liElement.classList.add('flex');
        let courseHeadingElement = document.createElement('h4');
        courseHeadingElement.textContent =
            `${name} - ${formatDate(date)}`;
        let deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('red');
        deleteButtonElement.textContent = 'Del';

        liElement.appendChild(courseHeadingElement);
        liElement.appendChild(deleteButtonElement);

        return liElement;
    }

    function formatDate(dateInput) {
        let [date, time] = dateInput.split('T');
        date = date.replaceAll(/-/g, '/');

        return `${date} - ${time}`;
    }
};