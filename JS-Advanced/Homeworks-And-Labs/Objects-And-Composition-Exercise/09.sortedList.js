function createSortedList() {
   class List{
    #sortArr = function (arr) {
        return arr.sort((a, b) => a-b);
    }

    constructor(){
        this.innerArray = [];
        this.size = 0;
    }
        add(el){
             this.innerArray.push(el);
             this.innerArray = this.#sortArr(this.innerArray);
             this.size++;
         };
     
        remove(index) {
             if (index >= 0 && index < this.innerArray.length) {
                 this.innerArray.splice(index,1);
                 this.innerArray = this.#sortArr(this.innerArray);
                 this.size--;
             }
         };
        get(index) {
             if (index >= 0 && index < this.innerArray.length) {
                return this.innerArray[index];
             }
         }
         
    }

   return new List();
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);

console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size);

