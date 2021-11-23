import auth from '../authService.js'

export default function createApi() {
    const endpoints = {
        REGISTER: 'users/register',
        LOGIN: 'users/login',
        LOGOUT: 'users/logout'
    }

    return {
        host(endpoint) {
            return `http://localhost:3030/${endpoint}`;
        },

        getOptions(headers) {
            const options = { headers: headers || {} };

            if (auth.isAuth()) {
                Object.assign(options.headers, { 'X-Authorization': auth.getToken() })
            }

            return options;
        },

        async requestAsync(endpoint, options) {
            let response;

            response = await fetch(endpoint, options);
            const contentType = response.headers.get('content-type');

            if (response.ok == false) {
                const err = await response.json();
                throw new Error(err.message);
            }

            if (response.status !== 204) {
                return await response.json();
            }
        },

        async getAsync(endpoint) {
            return this.requestAsync(this.host(endpoint), this.getOptions())
        },

        async postAsync(endpoint, body) {
            const options = this.getOptions({ 'Content-Type': 'application/json' })
            options.method = 'POST';
            options.body = JSON.stringify(body);

            return this.requestAsync(this.host(endpoint), options);
        },

        async putAsync(endpoint, body) {
            const options = this.getOptions({ 'Content-Type': 'application/json' });
            options.method = 'PUT';
            options.body = JSON.stringify(body);

            return this.requestAsync(this.host(endpoint), options);
        },

        async deleteAsync(endpoint) {
            const options = this.getOptions();
            options.method = 'DELETE';

            return this.requestAsync(this.host(endpoint), options);
        },

        async registerAsync(body) {
            const result = await this.postAsync(endpoints.REGISTER, body)

            sessionStorage.setItem('token', result.accessToken);
            sessionStorage.setItem('username', result.username);
            sessionStorage.setItem('userId', result._id);

            return result
        },

        async loginAsync(body) {
            const result = await this.postAsync(endpoints.LOGIN, body)

            sessionStorage.setItem('token', result.accessToken);
            sessionStorage.setItem('username', result.username);
            sessionStorage.setItem('userId', result._id);

            return result
        },

        async logoutAsync() {
            const result = await this.getAsync(endpoints.LOGOUT);
            sessionStorage.removeItem('token');
            sessionStorage.removeItem('username');
            sessionStorage.removeItem('userId');

            return result;
        }
    }
}