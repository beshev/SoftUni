let sections = document.querySelectorAll('section');

sections.forEach(section => {
    section.style.display = 'none';
});

let yearsSection = sections[0];
yearsSection.style.display = 'block';
yearsSection.addEventListener('click', onYearHandler);

let months = {
    Jan: 1,
    Feb: 2,
    Mar: 3,
    Apr: 4,
    May: 5,
    Jun: 6,
    Jul: 7,
    Aug: 8,
    Sept: 9,
    Oct: 10,
    Nov: 11,
    Dec: 12,
}

function onYearHandler(e) {
    let current = e.target;
    if (current.tagName !== 'TD' && current.tagName !== 'DIV') {
        return;
    }

    let year = current.tagName === 'TD' ? current.children[0].textContent : current.textContent;
    yearsSection.style.display = 'none';

    setMonth(year);
}

function setMonth(year) {
    let yearId = `year-${year}`;
    let monthSection = document.getElementById(yearId);
    monthSection.style.display = 'block';
    monthSection.addEventListener('click',setDays.bind(null,monthSection,year));
}

function setDays(monthSection,year,e) {
    monthSection.style.display = 'none';

    let current = e.target;
    if (current.tagName !== 'TD' && current.tagName !== 'DIV') {
        return;
    }

    let month = current.tagName === 'TD' ? current.children[0].textContent : current.textContent;
    let monthId = `month-${year}-${months[month]}`;

    let daysSection = document.getElementById(monthId);
    daysSection.style.display = 'block';
}