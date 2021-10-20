let { Repository } = require("./script");
let assert = require('chai').assert;

describe("Repository", function () {
    let properties;
    this.beforeEach(() => {
        properties = {
            name: "string",
            age: "number",
            birthday: "object"
        };
    })

    describe("constructor", function () {
        it("Instantiation should work", function () {
            let repo = new Repository(properties)

            assert.deepEqual(repo.props, {
                name: "string",
                age: "number",
                birthday: "object"
            })

            assert.equal(repo.nextId(), 0);
            assert.typeOf(repo.data, 'Map');
        });
    });

    describe("count", function () {
        it("count should work", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }
            assert.equal(repo.count, 0);

            repo.add(pesho);
            assert.equal(repo.count, 1);
        });
    })

    describe("add", function () {
        it("add should work", function () {
            let repo = new Repository(properties)
            let firstId = repo.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });

            let secondId = repo.add({
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            });

            assert.equal(firstId, 0);
            assert.equal(secondId, 1);
            assert.equal(repo.count, 2);
        });

        it("add should throw error if non-existing property is passed", function () {
            let repo = new Repository(properties)
            assert.throw(() => {
                repo.add({
                    name: "Pesho",
                    birthday: new Date(1998, 0, 7)
                })
            })

            assert.throw(() => {
                repo.add({
                    name: "Pesho",
                    age: 22,
                    peshoDate: new Date(1998, 0, 7)
                })
            }, 'Property birthday is missing from the entity!')

            assert.throw(() => {
                repo.add({
                    age: 22,
                    birthday: new Date(1998, 0, 7)
                })
            })
        });

        it("add should throw error if invalid property is passed", function () {
            let repo = new Repository(properties)
            assert.throw(() => {
                repo.add({
                    name: "Pesho",
                    age: '22',
                    birthday: '1998/01/07'
                })
            }, 'Property age is not of correct type!')

            assert.throw(() => {
                repo.add({
                    name: "Pesho",
                    age: '22',
                    birthday: new Date(1998, 0, 7)
                })
            })

            assert.throw(() => {
                repo.add({
                    name: 55,
                    age: 22,
                    birthday: new Date(1998, 0, 7)
                })
            })
        });
    })

    describe("getId", function () {
        it("getId should work", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }

            repo.add(pesho);
            repo.add(pesho);

            assert.deepEqual(pesho, repo.getId(0));
            assert.deepEqual(pesho, repo.getId(1));
        });

        it("getId throw error if Id not exist should work", function () {
            let repo = new Repository(properties)
            assert.throw(() => {
                repo.getId(0);
            })
        });
    })

    describe("update", function () {
        it("update throw error if entity with invalid params is passed", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }
            repo.add(pesho);

            let gosho = {
                name: "Gosho",
                age: 22,
                date: new Date(2000, 1, 1)
            }

            let tosho = {
                name: "Gosho",
                age: 22,
            }

            assert.throw(() => {
                repo.update(0, gosho)
            })

            assert.throw(() => {
                repo.update(0, tosho)
            })
        });

        it("update throw error if entity with invalid type is passed", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }
            repo.add(pesho);

            let gosho = {
                name: "Gosho",
                age: '22',
                birthday: new Date(1998, 0, 7)
            }

            let t = {
                name: "Gosho",
                age: 22,
                birthday: '1998, 0, 7'
            }

            assert.throw(() => {
                repo.update(0, gosho)
            })

            assert.throw(() => {
                repo.update(0, t)
            })
        });

        it("update throw error if Id not exist", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }

            assert.throw(() => {
                repo.update(0, pesho);
            })

            assert.throw(() => {
                repo.update(1, pesho);
            })

            assert.throw(() => {
                repo.update(-1, pesho);
            })
        });

        it("update  should work", function () {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }

            repo.add(pesho);
            repo.add(pesho);

            let gosho = {
                name: "Gosho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }

            repo.update(1, gosho);
            assert.deepEqual(repo.getId(1), gosho)
        });
    })

    describe('del', () => {
        it('Should work', () => {
            let repo = new Repository(properties)
            let pesho = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            }
            repo.add(pesho);
            repo.add(pesho);

            assert.equal(repo.count, 2);

            repo.del(0);
            repo.del(1);

            assert.equal(repo.count, 0);
        })

        it('Should throw error if id dont exist', () => {
            let repo = new Repository(properties)

            assert.throw(() => {
                repo.del(1);
            })
        })
    })
});
