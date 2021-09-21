function encodeAndDecodeMessages() {
    let senderButton = document.querySelectorAll('#main div button')[0];
    let recieverButton = document.querySelectorAll('#main div button')[1];

    let senderTextAreaElement = document.querySelectorAll('#main div textarea')[0];
    let recieverTextAreaElement = document.querySelectorAll('#main div textarea')[1];
    
    senderButton.addEventListener('click', (e) => {
        let textToEncode = senderTextAreaElement.value;
        let encodedText = '';

        for (let i = 0; i < textToEncode.length; i++) {
            encodedText += String.fromCharCode(textToEncode[i].charCodeAt() + 1);
        }

        recieverTextAreaElement.value = encodedText;
        senderTextAreaElement.value = '';
    })

    recieverButton.addEventListener('click', (e) => {
        let textToDecode = recieverTextAreaElement.value;
        let decodedText = '';
        for (let i = 0; i < textToDecode.length; i++) {
            decodedText += String.fromCharCode(textToDecode[i].charCodeAt() - 1);
        }
        recieverTextAreaElement.value = decodedText;
    });
}