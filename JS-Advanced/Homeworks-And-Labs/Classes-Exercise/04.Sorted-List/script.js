class List{
    constructor(){
        this.innerArray = [];
        this.size = 0;
    }

    add(el) {
        this.innerArray.push(el);
        this.innerArray.sort((a, b) => a-b);
        this.size++;
    }

    remove(index){
        if (index >= 0 && index < this.innerArray.length) {
            this.innerArray.splice(index,1);
            this.size--;
        }
    }

    get(index){
        if (index >= 0 && index < this.innerArray.length) {
            return this.innerArray[index];
        }
    }
}


let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.size);
console.log(list.get(1)); 
list.remove(1);
console.log(list.size);
console.log(list.get(1));
