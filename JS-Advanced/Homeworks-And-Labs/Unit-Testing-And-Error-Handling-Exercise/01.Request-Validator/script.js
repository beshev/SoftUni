function validateHttpRequest(httpRequest) {
    let allowedMethods = ['GET', 'POST', 'DELETE', 'CONNECT']
    let allowedHttpVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']

    let validatorObj = {
        method: function (type) {
            if (!allowedMethods.includes(type)) {
                errorHandler('method');
            }
        },
        uri: function (address) {
            // ^[*a-zA-Z.0-9]+$
            if (!address.match(/^[*a-zA-Z.0-9]+$/)) {
                errorHandler('URI');
            }
        },
        version: function (httpVersion) {
            if (!allowedHttpVersions.includes(httpVersion)) {
                errorHandler('version');
            }
        },
        message: function (message) {
            if (!message.match(/^([0-9]|[^<>\\&'"])*$/)) {
                errorHandler('message');
            }
        }
    }

    for (const key in validatorObj) {
        if (!httpRequest.hasOwnProperty(key)) {
            errorHandler(key);
        }

        validatorObj[key](httpRequest[key]);
    }

    return httpRequest;

    function errorHandler(header) {
        header = header == 'uri' ? 'URI' : header;
        header = header[0].toUpperCase() + header.slice(1);
        throw Error(`Invalid request header: Invalid ${header}`);
    }
}

console.log(validateHttpRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  }
  ));

console.log(validateHttpRequest({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}
));

  console.log(validateHttpRequest({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
    }
  ));


