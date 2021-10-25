let HolidayPackage = require('./script');
let assert = require('chai').assert;


describe("HolidayPackage", function () {
    let hp;
    this.beforeEach(() => {
        hp = new HolidayPackage('Italy', 'Summer');
    })

    describe("constructor", function () {
        it('Should instantiated with two parameters', () => {
            assert.isFalse(hp.insuranceIncluded);
            assert.equal(hp.season, 'Summer');
            assert.equal(hp.destination, 'Italy');
            assert.deepEqual(hp.vacationers, []);
        })
    });

    describe("insuranceIncluded getter", function () {
        it('Should work', () => {
            assert.isFalse(hp.insuranceIncluded);
        })
    });

    describe("insuranceIncluded setter", function () {
        it('Should work', () => {
           hp.insuranceIncluded = true;
           assert.isTrue(hp.insuranceIncluded);
        })

        it('Should throw error if non-boolean value is passed', () => {
            assert.throw(() => {
                hp.insuranceIncluded = 22;
            })

            assert.throw(() => {
                hp.insuranceIncluded = 'invalid value';
            })
         })

    });

    describe("showVacationers", function () {
        it('Should return massage for empty vacationers',() => {
            assert.equal(hp.showVacationers(),'No vacationers are added yet')
        })

        it('Should return vacationers',() => {
            hp.addVacationer('Pesho Peshev');
            hp.addVacationer('Gogo Goshev');
            hp.addVacationer('Stamat Omni');

            let expected = `Vacationers:
Pesho Peshev
Gogo Goshev
Stamat Omni`

            assert.equal(hp.showVacationers(),expected);
        })
    });


    describe("addVacationer", function () {
        it('Should throw error if vacationer name is empty space or is not a string',() => {
            assert.throw(() => {
                hp.addVacationer(22);
            })
            assert.throw(() => {
                hp.addVacationer(true);
            })
            assert.throw(() => {
                hp.addVacationer(' ');
            })
        })

        it('Should throw error if vacationer name not contain First and Last name',() => {
            assert.throw(() => {
                hp.addVacationer('StamatGoshev');
            })
            assert.throw(() => {
                hp.addVacationer('Pesho');
            })
            assert.throw(() => {
                hp.addVacationer('Peshev Ivanov Peshev');
            })
        })

        it('Should work',() => {
            hp.addVacationer('Pesho Peshev');
            hp.addVacationer('Gosho Goshev');

            assert.equal(hp.vacationers[0],'Pesho Peshev');
            assert.equal(hp.vacationers[1], 'Gosho Goshev')
        })
    });

    describe("generateHolidayPackage", function() {
        it('Should throw error if vacationers array is empty',() => {
            assert.throw(() => {
                hp.generateHolidayPackage();
            })
        })

        it('Should work for Summer season without insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Summer');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Price: 1000`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })

        it('Should work for Summer season with insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Summer');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');
            holiday.insuranceIncluded = true;

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Price: 1100`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })

        it('Should work for Winter season without insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Winter');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');
            holiday.addVacationer('Stamat Omni');

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Stamat Omni
Price: 1400`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })

        it('Should work for Winter season with insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Winter');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');
            holiday.addVacationer('Stamat Omni');
            holiday.insuranceIncluded = true;

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Stamat Omni
Price: 1500`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })

        it('Should work for no season and with insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Spring');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');
            holiday.addVacationer('Stamat Omni');
            holiday.insuranceIncluded = true;

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Stamat Omni
Price: 1300`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })

        it('Should work for no season and no insurance',() => {
            let holiday = new HolidayPackage('Italy', 'Spring');
            holiday.addVacationer('Pesho Peshev');
            holiday.addVacationer('Gosho Goshev');
            holiday.addVacationer('Stamat Omni');

            let expected = `Holiday Package Generated
Destination: Italy
Vacationers:
Pesho Peshev
Gosho Goshev
Stamat Omni
Price: 1200`

            assert.equal(holiday.generateHolidayPackage(),expected);
        })
    });
});

