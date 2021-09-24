function solve(inputArr) {
    let innerCollection = [];
    let commands ={
        add: function(value){
            innerCollection.push(value)
        },
        remove: function (value) {
            innerCollection = innerCollection.filter(x => x != value);
        },
        print: function () {
            console.log(innerCollection.join(','));
        }
    } 

    for (const args of inputArr) {
        let [command, value] = args.split(' ').filter(x => x != '');
        commands[command](value);
        
    }
}


solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);