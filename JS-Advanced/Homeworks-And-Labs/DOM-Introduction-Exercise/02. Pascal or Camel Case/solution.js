function solve() {
  //TODO...

  let words = document.querySelector('#text').value.split(' ');
  let namingConvention = document.querySelector('#naming-convention').value;


  if (namingConvention == 'Pascal Case') {
    words = wordsWithCapital(words);
    words[0] = words[0][0].toUpperCase() + words[0].slice(1).toLowerCase();
  } else if(namingConvention == 'Camel Case') {
    words = wordsWithCapital(words);
    words[0] = words[0][0].toLowerCase() + words[0].slice(1).toLowerCase();
  } 
  else {
    words = ['Error!'];
  }

  document.querySelector('#result').textContent = words.join('');

  function wordsWithCapital(words) {
    let result = [words[0]];
    for(let i = 1; i < words.length; i++){
      result.push(words[i][0].toUpperCase() + words[i].slice(1).toLowerCase());
    }

    return result;
  }
}
