function personAndTeacher() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString(placeHolder = '') {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email}${placeHolder})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString(`, subject: ${this.subject}`);
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString(`, course: ${this.course}`);
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}


let objects = personAndTeacher();
let Person = objects.Person;
let Teacher = objects.Teacher;
let Student = objects.Student;

let p = new Person('Jackie', 'Chan@abv.bg');
let t = new Teacher('Jason', 'Statom@abv.bg', 'DRY');
let s = new Student('Vin', 'Diesel@abv.bg', 'Js');


console.log(p.toString());
console.log(t.toString());
console.log(s.toString());