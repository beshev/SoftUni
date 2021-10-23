function solveClasses() {
    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let newTast = {
                id,
                taskName,
                priority,
            }

            if (priority == 'high') {
                this.tasks.unshift(newTast);
            } else {
                this.tasks.push(newTast);
            }

            return `Task id ${id}, with ${priority} priority, has been added.`;
        }

        doTask() {
            let task = this.tasks.shift();

            if (this.tasks.length == 0) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`;
            }

            return task.taskName;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            let result = [
                'Tasks, that need to be completed:'
            ]

            this.tasks.forEach(t => {
                result.push(`${t.id}: ${t.taskName} - ${t.priority}`)
            })

            return result.join('\n');
        }
    }

    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary += Number(bonus);
            this.experience = Number(experience);
        }

        learn(years) {
            this.experience += Number(years);
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary += Number(bonus);
            this.experience = Number(experience) + 5;
        }

        changeTaskPriority(taskId) {
            let t = this.tasks.find(x => x.id == taskId);
            this.tasks.splice(this.tasks.indexOf(t),1);

            if (t.priority == 'high') {
                t.priority = 'low';
                this.tasks.push(t);
            } else {
                t.priority = 'high';
                this.tasks.unshift(t);
            }

            return t;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}

let classes = solveClasses();
const developer = new classes.Developer("George", "Joestar");
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Update repository", "high"));
console.log(developer.reviewTasks());
console.log(developer.getSalary());

const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
console.log(junior.getSalary());

const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
senior.addTask(1, "Create functionality", "low");
senior.addTask(2, "Update functionality", "high");
console.log(senior.changeTaskPriority(1)["priority"]);



