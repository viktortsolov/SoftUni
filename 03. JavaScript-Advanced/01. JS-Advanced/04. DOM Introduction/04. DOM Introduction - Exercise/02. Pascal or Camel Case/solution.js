function solve() {
  let inputText = document.querySelector('#text').value.toLowerCase();
  let namingConvention = document.querySelector('#naming-convention').value;

  let result = '';

  switch (namingConvention) {
    case 'Camel Case':
      for (let i = 0; i < inputText.length; i++) {
        if (inputText[i] == ' ') {
          result += inputText[i + 1].toUpperCase();
          i++;
          continue;
        }
        result += inputText[i];
      }
      break;
    case 'Pascal Case':
      result += inputText[0].toUpperCase();
      for (let i = 1; i < inputText.length; i++) {
        if (inputText[i] == ' ') {
          result += inputText[i + 1].toUpperCase();
          i++;
          continue;
        }
        result += inputText[i];
      }
      break;

    default:
      result = 'Error!';
      break;
  }

  document.querySelector('#result').textContent += result;
}