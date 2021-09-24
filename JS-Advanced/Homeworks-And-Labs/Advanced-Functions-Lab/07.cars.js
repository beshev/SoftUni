function solve(commands) {
    let baseObj = {};
    
    for (const type of commands) {
        let args = type.split(' ');
        let [command, objName, key, value] = args;

        if (command == 'create' && args.length == 2) {
            createObj(objName);
        } else if (command == 'create' && args.length > 2) {
            createObjWithParent(objName,value); 
        } else if (command == 'set') {
            baseObj[objName][key] = value;
        } else {
           console.log(print(objName).join(', '));
        }
    }
    
    
    function createObj(objName) {
        baseObj[objName] = {};
    }
    
    function createObjWithParent(objName, parentName) {
        createObj(objName);
        baseObj[objName].parent = parentName;
    }

    function print(objName) {
        let currentObj = baseObj[objName];
        let allKeysValues = [];

        for (const key of Object.keys(currentObj).filter(x => x != 'parent')) {
            allKeysValues.push(`${key}:${currentObj[key]}`);
        }

        if (currentObj.hasOwnProperty('parent')) {
            print(currentObj.parent).forEach(el => {
                allKeysValues.push(el);
            });
        }

        return allKeysValues;
    }
}

let commands2 = ['create pesho','create gosho inherit pesho','create stamat inherit gosho','set pesho rank number1','set gosho nick goshko','print stamat'];
let commands = ['create c1','create c2 inherit c1','set c1 color red','set c2 model new','print c1','print c2'];

solve(commands);