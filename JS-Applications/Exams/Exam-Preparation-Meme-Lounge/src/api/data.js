import createApi from './api.js'

const endpoints = {
    RESOURCES: 'data/memes',
    RESOURCES_ORDER: 'data/memes?sortBy=_createdOn%20desc',
    MEME_BY_ID: 'data/memes/'
}

const api = createApi();

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function getResourceById(id) {
    return await api.get(endpoints.MEME_BY_ID + id);
}

export async function getAllResources() {
    return await api.get(endpoints.RESOURCES_ORDER);
}

export async function editResourceById(id, body) {
    return await api.put(endpoints.MEME_BY_ID + id, body)
}

export async function createResource(body) {
    return await api.post(endpoints.RESOURCES, body);
}

export async function deleteResourceById(id) {
    return await api.delete(endpoints.MEME_BY_ID + id)
}