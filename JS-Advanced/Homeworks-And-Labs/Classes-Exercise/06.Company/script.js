class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {
        this.validateInput(username);
        this.validateInput(salary);
        this.validateInput(position);
        this.validateInput(department);

        if (!this.departments[department]) {
            this.departments[department] = {
                departmentName: department,
                avgSalary: 0,
                people: [],
            }
        }

        this.departments[department].people.push({
            username,
            salary,
            position
        });

        this.departments[department].avgSalary = this.departments[department].people.reduce((acc, x, i, arr) => acc + (x.salary / arr.length), 0)

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = Object.entries(this.departments).sort((a, b) => b[1].avgSalary - a[1].avgSalary)[0];
        let result = `Best Department is: ${bestDepartment[0]}\n`;
        result += `Average salary: ${bestDepartment[1].avgSalary.toFixed(2)}\n`;

        bestDepartment[1].people.sort((a, b) => {
            let comparer = b.salary - a.salary;
            if (comparer == 0) {
                comparer = a.username.localeCompare(b.username);
            }
            return comparer;
        }).forEach(person => {
            result += `${person.username} ${person.salary} ${person.position}\n`;
        });

        return result.trimEnd('\n');
    }


    validateInput = function (input) {
        if (input == '' || input == undefined || input == null) {
            throw new Error('Invalid input!');
        }

        if (!isNaN(input)) {
            if (input < 0) {
                throw new Error('Invalid input!');
            }
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
