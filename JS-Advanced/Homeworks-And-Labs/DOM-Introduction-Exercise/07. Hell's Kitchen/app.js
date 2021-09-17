function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      //   TODO:
      let restaurants = getRestaurantsWithWorkers();

      let bestRestaurant = {};
      
         for (const key in restaurants) {
           let name = key;
           let people = restaurants[key];

           let currentRest = {
            name: name,
            people: people,
            avgSalary: people.map(x => x[1]).reduce((a, x) => a + x,0) / people.length,
            bestSalary: people[0][1],
         };

         if (Object.keys(bestRestaurant) == 0 || currentRest.avgSalary > bestRestaurant.avgSalary) {
            bestRestaurant = currentRest;
         }
      }

      document.querySelector('#bestRestaurant p').textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`

      document.querySelector('#workers p').textContent = bestRestaurant.people.map(x => `Name: ${x[0]} With Salary: ${x[1]}`).join(' ');
   }

   function getRestaurantsWithWorkers() {
         let input = JSON.parse(document.querySelector('#inputs textarea').value);
         let restaurants = {};
         for (const objInfo of input) {
            let [restName,people] = objInfo.split(' - ');
            people = getPeople(people);
            
            if (restaurants.hasOwnProperty(restName)) {
               people.forEach(element => {
                  restaurants[restName].push(element);
               });
            } else {
               restaurants[restName] = people;
            }

            restaurants[restName].sort((a, b) => b[1] - a[1]);
         }

         return restaurants;

         // getting workers
         function getPeople(input) {
            return input.split(', ').map(x => {
            let [persoName,salary] = x.split(' ');
            return [persoName,Number(salary)];
         });
      } 
   }
}