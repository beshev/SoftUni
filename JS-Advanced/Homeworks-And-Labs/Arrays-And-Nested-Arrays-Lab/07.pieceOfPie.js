function main(array,startValue,endValue) {
    let startIndex = array.indexOf(startValue);
    let endIndex = array.indexOf(endValue);

    return array.slice(startIndex,++endIndex);
}

console.log(main(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));
console.log(main(['Apple Crisp',
'Mississippi Mud Pie',
'Pot Pie',
'Steak and Cheese Pie',
'Butter Chicken Pie',
'Smoked Fish Pie'],
'Pot Pie',
'Smoked Fish Pie'
));