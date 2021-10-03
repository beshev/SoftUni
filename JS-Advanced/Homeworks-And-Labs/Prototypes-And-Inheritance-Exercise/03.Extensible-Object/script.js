function extensibleObject() {
    const proto = {};
    const myObj = Object.create(proto);
    myObj.extend = function (templates) {
        Object.entries(templates).forEach(([key, value]) => {
            if (typeof value === 'function') {
                proto[key] = value;
            } else {
                myObj[key] = value;
            }
        })
    }
    return myObj;
}
