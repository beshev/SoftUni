import auth from '../auth.js'

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

        async request(endpoint, options) {
            let response;

            response = await fetch(endpoint, options);

            if (response.ok == false) {
                const err = await response.json();
                throw new Error(err.message);
            }

            if (response.status !== 204 && response.body) {
                return await response.json();
            }
        },

        async get(endpoint) {
            return this.request(this.host(endpoint), this.getOptions())
        },

        async post(endpoint, body) {
            const options = this.getOptions({ 'Content-Type': 'application/json' })
            options.method = 'POST';
            options.body = JSON.stringify(body);

            return this.request(this.host(endpoint), options);
        },

        async put(endpoint, body) {
            const options = this.getOptions({ 'Content-Type': 'application/json' });
            options.method = 'PUT';
            options.body = JSON.stringify(body);

            return this.request(this.host(endpoint), options);
        },

        async delete(endpoint) {
            const options = this.getOptions();
            options.method = 'DELETE';

            return this.request(this.host(endpoint), options);
        },

        async register(body) {
            const result = await this.post(endpoints.REGISTER, body)

            sessionStorage.setItem('token', result.accessToken);
            sessionStorage.setItem('email', result.email);
            sessionStorage.setItem('userId', result._id);
            sessionStorage.setItem('username', result.username);
            sessionStorage.setItem('gender', result.gender);

            return result
        },

        async login(body) {
            const result = await this.post(endpoints.LOGIN, body)

            sessionStorage.setItem('token', result.accessToken);
            sessionStorage.setItem('email', result.email);
            sessionStorage.setItem('userId', result._id);
            sessionStorage.setItem('username', result.username);
            sessionStorage.setItem('gender', result.gender);

            return result
        },

        async logout() {
            const result = await fetch('http://localhost:3000/users/logout', {
                headers: { 'X-Authorization': sessionStorage.getItem('token') }
            })
            sessionStorage.removeItem('token');
            sessionStorage.removeItem('email');
            sessionStorage.removeItem('userId');
            sessionStorage.removeItem('username');
            sessionStorage.removeItem('gender');

            return result;
        }
    }
}